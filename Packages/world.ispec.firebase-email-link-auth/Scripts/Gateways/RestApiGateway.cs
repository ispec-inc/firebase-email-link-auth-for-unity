using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace ispec.FirebaseEmailLinkAuth
{
    internal interface IRestApiGateway
    {
        public Task<T> Get<T>(string url);
        public Task<T> Post<T>(string url, object param);
    }

    internal class RestApiGateway : IRestApiGateway
    {
        public Task<T> Get<T>(string url)
        {
            return ProcessRequest<T>(UnityWebRequest.Get(url));
        }

        public Task<T> Post<T>(string url, object param)
        {
            var request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST);
            var bodyRaw = Encoding.UTF8.GetBytes(param.ToJson(
                new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                }
            ));
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            return ProcessRequest<T>(request);
        }

        private static async Task<T> ProcessRequest<T>(UnityWebRequest request)
        {
            var requestResult = await ExecuteRequestToGetTask(request);
            AssertRequestErrors(request);
            return requestResult.FromJson<T>();
        }

        private static void AssertRequestErrors(UnityWebRequest request)
        {
            if (
                request.result is
                UnityWebRequest.Result.ProtocolError or
                UnityWebRequest.Result.ConnectionError
            )
            {
                throw new Exception(request.error);
            }
        }

        private static Task<string> ExecuteRequestToGetTask(UnityWebRequest request)
        {
            var asyncRequest = request.SendWebRequest();
            var taskCompletionSource = new TaskCompletionSource<string>();
            asyncRequest.completed += _ =>
                taskCompletionSource.SetResult(request.downloadHandler.text);
            return taskCompletionSource.Task;
        }
    }
}
