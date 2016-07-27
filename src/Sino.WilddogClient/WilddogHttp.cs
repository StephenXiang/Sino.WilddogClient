using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sino.WilddogClient
{
	public class WilddogHttp : IWilddogHttp
	{
		public const string HTTP_METHOD_OVERRIDE = "x-http-method-override";

		public string Auth { get; set; }

		public bool MethodOverride { get; set; }

		protected string GetUrl(string url, bool useAuth)
		{
			if (!useAuth)
				return url;
			if (url.Contains("?"))
			{
				return url + "&auth=" + Auth;
			}
			else
			{
				return url + "?auth=" + Auth;
			}
		}

		public string Delete(string url, bool useAuth = false)
		{
			return DeleteAsync(url, useAuth).Result;
		}

		public Task<string> DeleteAsync(string url, bool useAuth = false)
		{
			url = GetUrl(url, useAuth);
			return SendAsync(url, HttpMethod.Delete);
		}

		public string Get(string url, bool useAuth = false)
		{
			return GetAsync(url, useAuth).Result;
		}

		public Task<string> GetAsync(string url, bool useAuth = false)
		{
			url = GetUrl(url, useAuth);
			return SendAsync(url, HttpMethod.Get);
		}

		public string Patch(string url, string body, bool useAuth = false)
		{
			return PatchAsync(url, body, useAuth).Result;
		}

		public Task<string> PatchAsync(string url, string body, bool useAuth = false)
		{
			url = GetUrl(url, useAuth);
			if (url.Contains("?"))
			{
				url += ("&" + HTTP_METHOD_OVERRIDE + "PATCH");
			}
			else
			{
				url += ("?" + HTTP_METHOD_OVERRIDE + "PATCH");
			}
			return SendAsync(url, HttpMethod.Post, body);
		}

		public string Post(string url, string body, bool useAuth = false)
		{
			return PostAsync(url, body, useAuth).Result;
		}

		public Task<string> PostAsync(string url, string body, bool useAuth = false)
		{
			url = GetUrl(url, useAuth);
			return SendAsync(url, HttpMethod.Post, body);
		}

		public string Put(string url, string body, bool useAuth = false)
		{
			return PutAsync(url, body, useAuth).Result;
		}

		public Task<string> PutAsync(string url, string body, bool useAuth = false)
		{
			url = GetUrl(url, useAuth);
			return SendAsync(url, HttpMethod.Put, body);
		}

		/// <summary>
		/// 发送请求
		/// </summary>
		/// <param name="url">请求的路径</param>
		/// <param name="method">请求方法</param>
		/// <param name="body">需要发送的数据</param>
		/// <returns>返回的数据</returns>
		protected async Task<string> SendAsync(string url, HttpMethod method, string body = "")
		{
			if (string.IsNullOrEmpty(url))
			{
				throw new ArgumentNullException(nameof(url));
			}

			if (!url.Contains(HTTP_METHOD_OVERRIDE) && MethodOverride)
			{
				if (url.Contains("?"))
				{
					url += ("&" + HTTP_METHOD_OVERRIDE + method.Method);
				}
				else
				{
					url += ("?" + HTTP_METHOD_OVERRIDE + method.Method);
				}
			}

			HttpClient client = new HttpClient();
			HttpResponseMessage response = null;
			if (method == HttpMethod.Get)
			{
				response = await client.GetAsync(url);
			}
			else if (method == HttpMethod.Delete)
			{
				response = await client.DeleteAsync(url);
			}
			else if (method == HttpMethod.Post)
			{
				response = await client.PostAsync(url, new StringContent(body));
			}
			else if (method == HttpMethod.Put)
			{
				response = await client.PutAsync(url, new StringContent(body));
			}
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				return await response.Content.ReadAsStringAsync();
			}
			else
			{
				throw new InvalidOperationException();
			}
		}
	}
}
