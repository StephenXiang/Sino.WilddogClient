using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Sino.WilddogClient
{
	public class WilddogClient : IWilddog
	{
		private string _url;
		private IWilddogHttp _http;

		public WilddogClient(string url)
			: this(url, new WilddogHttp()) { }

		public WilddogClient(string url, IWilddogHttp http)
		{
			if (string.IsNullOrEmpty(url))
				throw new ArgumentNullException(nameof(url));
			if (http == null)
				throw new ArgumentNullException(nameof(http));

			_url = url;
			_http = http;
		}

		/// <summary>
		/// 验证Path参数是否符合要求
		/// </summary>
		protected bool ValidPath(string path)
		{
			if (path.StartsWith("http:") || path.StartsWith("https:") || path.StartsWith("/"))
			{
				return false;
			}
			return true;
		}

		protected string GetPath(string url, string path, Options options = null)
		{
			if (string.IsNullOrEmpty(url))
				throw new ArgumentNullException(nameof(url));
			if (string.IsNullOrEmpty(path))
				throw new ArgumentNullException(nameof(path));

			return url + "/" + path;
		}

		protected void SetAuth(string selfAuth)
		{
			_http.Auth = string.IsNullOrEmpty(selfAuth) ? Auth : selfAuth;
		}

		protected string GetJsonString(object obj)
		{
			return JsonConvert.SerializeObject(obj);
		}

		protected TReturn GetObject<TReturn>(string json)
		{
			return JsonConvert.DeserializeObject<TReturn>(json);
		}

		public string Auth { get; set; }

		public bool MethodOverride
		{
			get
			{
				return _http.MethodOverride;
			}
			set
			{
				_http.MethodOverride = value;
			}
		}

		public IWilddog Child(string path)
		{
			if (ValidPath(path))
			{
				return new WilddogClient(_url + "/" + path, _http);
			}
			throw new ArgumentException("path can not start with 'http:','https:','/'");
		}

		public string Delete(bool useAuth = false, string auth = "")
		{
			return DeleteAsync(useAuth, auth).Result;
		}

		public string Delete(string path, bool useAuth = false, string auth = "")
		{
			return DeleteAsync(path, useAuth, auth).Result;
		}

		public TReturn Delete<TReturn>(bool useAuth = false, string auth = "")
		{
			return DeleteAsync<TReturn>(useAuth, auth).Result;
		}

		public TReturn Delete<TReturn>(string path, bool useAuth = false, string auth = "")
		{
			return DeleteAsync<TReturn>(path, useAuth, auth).Result;
		}

		public Task<string> DeleteAsync(bool useAuth = false, string auth = "")
		{
			_http.Auth = string.IsNullOrEmpty(auth) ? Auth : auth;
			return _http.DeleteAsync(_url, useAuth);
		}

		public Task<string> DeleteAsync(string path, bool useAuth = false, string auth = "")
		{
			string url = GetPath(_url, path);
			SetAuth(auth);
			return _http.DeleteAsync(url, useAuth);
		}

		public async Task<TReturn> DeleteAsync<TReturn>(bool useAuth = false, string auth = "")
		{
			string response = await DeleteAsync(useAuth, auth);
			return GetObject<TReturn>(response);
		}

		public async Task<TReturn> DeleteAsync<TReturn>(string path, bool useAuth = false, string auth = "")
		{
			string response = await DeleteAsync(path, useAuth, auth);
			return GetObject<TReturn>(response);
		}

		public string Insert(object data, bool useAuth = false, string auth = "")
		{
			return InsertAsync(data, useAuth, auth).Result;
		}

		public string Insert(string path, object data, bool useAuth = false, string auth = "")
		{
			return InsertAsync(path, data, useAuth, auth).Result;
		}

		public TReturn Insert<TReturn>(object data, bool useAuth = false, string auth = "")
		{
			return InsertAsync<TReturn>(data, useAuth, auth).Result;
		}

		public TReturn Insert<TReturn>(string path, object data, bool useAuth = false, string auth = "")
		{
			return InsertAsync<TReturn>(path, data, useAuth, auth).Result;
		}

		public Task<string> InsertAsync(object data, bool useAuth = false, string auth = "")
		{
			SetAuth(auth);
			string jsonData = GetJsonString(data);
			return _http.PostAsync(_url, jsonData, useAuth);
		}

		public Task<string> InsertAsync(string path, object data, bool useAuth = false, string auth = "")
		{
			string url = GetPath(_url, path);
			SetAuth(auth);
			string jsonData = GetJsonString(data);
			return _http.PostAsync(url, jsonData, useAuth);
		}

		public async Task<TReturn> InsertAsync<TReturn>(object data, bool useAuth = false, string auth = "")
		{
			string response = await InsertAsync(data, useAuth, auth);
			return GetObject<TReturn>(response);
		}

		public async Task<TReturn> InsertAsync<TReturn>(string path, object data, bool useAuth = false, string auth = "")
		{
			string response = await InsertAsync(path, data, useAuth, auth);
			return GetObject<TReturn>(response);
		}

		public string Patch(object data, bool useAuth = false, string auth = "")
		{
			return PatchAsync(data, useAuth, auth).Result;
		}

		public string Patch(string path, object data, bool useAuth = false, string auth = "")
		{
			return PatchAsync(path, data, useAuth, auth).Result;
		}

		public TReturn Patch<TReturn>(object data, bool useAuth = false, string auth = "")
		{
			return PatchAsync<TReturn>(data, useAuth, auth).Result;
		}

		public TReturn Patch<TReturn>(string path, object data, bool useAuth = false, string auth = "")
		{
			return PatchAsync<TReturn>(path, data, useAuth, auth).Result;
		}

		public Task<string> PatchAsync(object data, bool useAuth = false, string auth = "")
		{
			SetAuth(auth);
			string jsonData = GetJsonString(data);
			return _http.PatchAsync(_url, jsonData, useAuth);
		}

		public Task<string> PatchAsync(string path, object data, bool useAuth = false, string auth = "")
		{
			string url = GetPath(_url, path);
			string jsonData = GetJsonString(data);
			SetAuth(auth);
			return _http.PatchAsync(url, jsonData, useAuth);
		}

		public async Task<TReturn> PatchAsync<TReturn>(object data, bool useAuth = false, string auth = "")
		{
			string response = await PatchAsync(data, useAuth, auth);
			return GetObject<TReturn>(response);
		}

		public async Task<TReturn> PatchAsync<TReturn>(string path, object data, bool useAuth = false, string auth = "")
		{
			string response = await PatchAsync(path, data, useAuth, auth);
			return GetObject<TReturn>(response);
		}

		public string Query(bool useAuth = false, string auth = "", Options options = null)
		{
			return QueryAsync(useAuth, auth, options).Result;
		}

		public string Query(string path, bool useAuth = false, string auth = "", Options options = null)
		{
			return QueryAsync(path, useAuth, auth, options).Result;
		}

		public TReturn Query<TReturn>(bool useAuth = false, string auth = "", Options options = null)
		{
			return QueryAsync<TReturn>(useAuth, auth, options).Result;
		}

		public TReturn Query<TReturn>(string path, bool useAuth = false, string auth = "", Options options = null)
		{
			return QueryAsync<TReturn>(path, useAuth, auth, options).Result;
		}

		public Task<string> QueryAsync(bool useAuth = false, string auth = "", Options options = null)
		{
			string url = GetPath(_url, "", options);
			SetAuth(auth);
			return _http.GetAsync(url, useAuth);
		}

		public Task<string> QueryAsync(string path, bool useAuth = false, string auth = "", Options options = null)
		{
			string url = GetPath(_url, path, options);
			SetAuth(auth);
			return _http.GetAsync(url, useAuth);
		}

		public async Task<TReturn> QueryAsync<TReturn>(bool useAuth = false, string auth = "", Options options = null)
		{
			string response = await QueryAsync(useAuth, auth, options);
			return GetObject<TReturn>(response);
		}

		public async Task<TReturn> QueryAsync<TReturn>(string path, bool useAuth, string auth = "", Options options = null)
		{
			string response = await QueryAsync(path, useAuth, auth, options);
			return GetObject<TReturn>(response);
		}

		public string Update(object data, bool useAuth = false, string auth = "")
		{
			return UpdateAsync(data, useAuth, auth).Result;
		}

		public string Update(string path, object data, bool useAuth = false, string auth = "")
		{
			return UpdateAsync(path, data, useAuth, auth).Result;
		}

		public TReturn Update<TReturn>(object data, bool useAuth = false, string auth = "")
		{
			return UpdateAsync<TReturn>(data, useAuth, auth).Result;
		}

		public TReturn Update<TReturn>(string path, object data, bool useAuth = false, string auth = "")
		{
			return UpdateAsync<TReturn>(path, data, useAuth, auth).Result;
		}

		public Task<string> UpdateAsync(object data, bool useAuth = false, string auth = "")
		{
			SetAuth(auth);
			string jsonData = GetJsonString(data);
			return _http.PutAsync(_url, jsonData, useAuth);
		}

		public Task<string> UpdateAsync(string path, object data, bool useAuth = false, string auth = "")
		{
			string url = GetPath(_url, path);
			string jsonData = GetJsonString(data);
			SetAuth(auth);
			return _http.PutAsync(url, jsonData, useAuth);
		}

		public async Task<TReturn> UpdateAsync<TReturn>(object data, bool useAuth = false, string auth = "")
		{
			string response = await UpdateAsync(data, useAuth, auth);
			return GetObject<TReturn>(response);
		}

		public async Task<TReturn> UpdateAsync<TReturn>(string path, object data, bool useAuth = false, string auth = "")
		{
			string response = await UpdateAsync(path, data, useAuth, auth);
			return GetObject<TReturn>(response);
		}
	}
}
