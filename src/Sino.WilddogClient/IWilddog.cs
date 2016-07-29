using System.Threading.Tasks;

namespace Sino.WilddogClient
{
	/// <summary>
	/// 野狗公开API
	/// </summary>
	public interface IWilddog
	{
		/// <summary>
		/// 获取子节点
		/// </summary>
		/// <param name="path">子节点名</param>
		IWilddog Child(string path);

		/// <summary>
		/// 查询数据
		/// </summary>
		/// <param name="useAuth">是否需要认证</param>
		/// <param name="auth">在需要单独设置该方法的令牌的时候传值</param>
		/// <param name="options">用于排序和分页</param>
		TReturn Query<TReturn>(bool useAuth = false, string auth = "", Options options = null);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="path"></param>
        /// <param name="useAuth"></param>
        /// <param name="auth"></param>
        /// <param name="options"></param>
        /// <returns></returns>
		TReturn Query<TReturn>(string path, bool useAuth = false, string auth = "", Options options = null);

		string Query(bool useAuth = false, string auth = "", Options options = null);

		string Query(string path, bool useAuth = false, string auth = "", Options options = null);

		Task<TReturn> QueryAsync<TReturn>(bool useAuth = false, string auth = "", Options options = null);

		Task<TReturn> QueryAsync<TReturn>(string path, bool useAuth, string auth = "", Options options = null);

		Task<string> QueryAsync(bool useAuth = false, string auth = "", Options options = null);

		Task<string> QueryAsync(string path, bool useAuth = false, string auth = "", Options options = null);

		/// <summary>
		/// 添加数据
		/// </summary>
		TReturn Insert<TReturn>(object data, bool useAuth = false, string auth = "");

		TReturn Insert<TReturn>(string path, object data, bool useAuth = false, string auth = "");

		string Insert(object data, bool useAuth = false, string auth = "");

		string Insert(string path, object data, bool useAuth = false, string auth = "");

		Task<TReturn> InsertAsync<TReturn>(object data, bool useAuth = false, string auth = "");

		Task<TReturn> InsertAsync<TReturn>(string path, object data, bool useAuth = false, string auth = "");

		Task<string> InsertAsync(object data, bool useAuth = false, string auth = "");

		Task<string> InsertAsync(string path, object data, bool useAuth = false, string auth = "");

		/// <summary>
		/// 更新数据
		/// </summary>
		TReturn Update<TReturn>(object data, bool useAuth = false, string auth = "");

		TReturn Update<TReturn>(string path, object data, bool useAuth = false, string auth = "");

		string Update(object data, bool useAuth = false, string auth = "");

		string Update(string path, object data, bool useAuth = false, string auth = "");

		Task<TReturn> UpdateAsync<TReturn>(object data, bool useAuth = false, string auth = "");

		Task<TReturn> UpdateAsync<TReturn>(string path, object data, bool useAuth = false, string auth = "");

		Task<string> UpdateAsync(object data, bool useAuth = false, string auth = "");

		Task<string> UpdateAsync(string path, object data, bool useAuth = false, string auth = "");

		/// <summary>
		/// 更新需要更新部分
		/// </summary>
		TReturn Patch<TReturn>(object data, bool useAuth = false, string auth = "");

		TReturn Patch<TReturn>(string path, object data, bool useAuth = false, string auth = "");

		string Patch(object data, bool useAuth = false, string auth = "");

		string Patch(string path, object data, bool useAuth = false, string auth = "");

		Task<TReturn> PatchAsync<TReturn>(object data, bool useAuth = false, string auth = "");

		Task<TReturn> PatchAsync<TReturn>(string path, object data, bool useAuth = false, string auth = "");

		Task<string> PatchAsync(object data, bool useAuth = false, string auth = "");

		Task<string> PatchAsync(string path, object data, bool useAuth = false, string auth = "");

		/// <summary>
		/// 删除数据
		/// </summary>
		TReturn Delete<TReturn>(bool useAuth = false, string auth = "");

		TReturn Delete<TReturn>(string path, bool useAuth = false, string auth = "");

		string Delete(bool useAuth = false, string auth = "");

		string Delete(string path, bool useAuth = false, string auth = "");

		Task<TReturn> DeleteAsync<TReturn>(bool useAuth = false, string auth = "");

		Task<TReturn> DeleteAsync<TReturn>(string path, bool useAuth = false, string auth = "");

		Task<string> DeleteAsync(bool useAuth = false, string auth = "");

		Task<string> DeleteAsync(string path, bool useAuth = false, string auth = "");

		string Auth { get; set; }

		bool MethodOverride { get; set; }
	}
}
