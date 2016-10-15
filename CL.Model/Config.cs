
//-------------------------------------------------------------------

//版权所有：版权所有(C) 2014，WZ
//系统名称： 
//文件名称：Config.cs
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
	[Table("T_Config")]
	public partial class Config : IEntity    
	{
		#region Model
		/// <summary>
		/// 
		/// </summary>
		[Id]
		public int ICId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CValue { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column(Length=500)]
		public string CRemark { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? IUserId { get; set; }
		#endregion
	}
}
   