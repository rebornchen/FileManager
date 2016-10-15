
//-------------------------------------------------------------------

//版权所有：版权所有(C) 2016，CL
//系统名称： 
//文件名称：SSNEmail.cs
//模块名称：
//作　　者：Chenlin
//创建时间：
//功能说明：
//-----------------------------------------------------------------
//修改记录： 
//修改人：   
//修改时间： 
//修改内容： 
//-----------------------------------------------------------------  
using NLite; 
using System;
using NLite.Data;    
using Newtonsoft.Json; 
using CL.Model.Interfaces;
namespace CL.Model   
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[Table("SSNEmail")]
	public partial class SSNEmail : IEntity    
	{
		#region Model
		/// <summary>
		/// 
		/// </summary>
		public bool _Locked { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal? _SortKey { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Email { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column(Length=10000)]
		public string Remark { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Pwd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int _Identify { get; set; }
		#endregion
	}
}
   