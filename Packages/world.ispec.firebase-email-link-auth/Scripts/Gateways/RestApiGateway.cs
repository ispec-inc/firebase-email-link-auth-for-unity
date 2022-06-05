using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace ispec.FirebaseEmailLinkAuth
{
    internal interface IRestApiGateway
    {
        public Task<T> Get<T>(string url);
        public Task<T> Post<T>(string url, Dictionary<string, string> param = null);
    }

    internal class RestApiGateway : IRestApiGateway
    {
        public Task<T> Get<T>(string url)
        {
            return ProcessRequest<T>(UnityWebRequest.Get(url));
        }

        public Task<T> Post<T>(string url, Dictionary<string, string> param = null)
        {
            param ??= new Dictionary<string, string>();
            return ProcessRequest<T>(UnityWebRequest.Post(url, param));
        }

        private static async Task<T> ProcessRequest<T>(UnityWebRequest request)
        {
            var requestResult = await ExecuteRequestToGetTask(request);
            AssertRequestErrors(request);
            return JsonConverter.FromJson<T>(requestResult);
        }

        private static void AssertRequestErrors(UnityWebRequest request)
        {
            if (
                request.result == UnityWebRequest.Result.ProtocolError ||
                request.result == UnityWebRequest.Result.ConnectionError
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
