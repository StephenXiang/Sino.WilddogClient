using System.Threading.Tasks;

namespace Sino.WilddogClient
{
	/// <summary>
	/// 底层Http请求接口
	/// </summary>
	public interface IWilddogHttp
	{
		string Get(string url, bool useAuth = false);

		Task<string> GetAsync(string url, bool useAuth = false);

		string Put(string url, string body, bool useAuth = false);

		Task<string> PutAsync(string url, string body, bool useAuth = false);

		string Post(string url, string body, bool useAuth = false);

		Task<string> PostAsync(string url, string body, bool useAuth = false);

		string Patch(string url, string body, bool useAuth = false);

		Task<string> PatchAsync(string url, string body, bool useAuth = false);

		string Delete(string url, bool useAuth = false);

		Task<string> DeleteAsync(string url, bool useAuth = false);

		bool MethodOverride { get; set; }

		string Auth { get; set; }
	}
}
