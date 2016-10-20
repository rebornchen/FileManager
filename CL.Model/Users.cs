
//-------------------------------------------------------------------

//版权所有：版权所有(C) 2016，CL
//系统名称： 
//文件名称：Users.cs
//模块名称：
//作　　者：Chenlin
//创建时间：2015/4/11 
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
	[Table("T_Users")]
	public partial class Users : IEntity    
	{
		#region Model
		/// <summary>
		/// 
		/// </summary>
		[Id]
		public int IUId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CUserName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CRealName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column(Length=500)]
		public string CRemark { get; set; }
		#endregion
	}
}
   