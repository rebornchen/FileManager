
//-------------------------------------------------------------------

//版权所有：版权所有(C) 2016，CL
//系统名称： 
//文件名称：SSN.cs
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
	[Table("SSN")]
	public partial class SSN : IEntity    
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
		public string 全名 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 性别 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Firstname { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Lastname { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Middlename { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 称呼 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 生日 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 州 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 街道地址 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 城市 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 电话 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 邮编 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 州全称 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string SSN社会保险号 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 网络用户名 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 随机密码 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 信用卡类型 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 信用卡号 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CVV2 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 有效期 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 职位 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 所属公司 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 身高 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string 体重 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int _Identify { get; set; }

        public string Country { get; set; }

        public string Remark { get; set; }
		#endregion
	}
}
   