
//-------------------------------------------------------------------

//版权所有：版权所有(C) 2014，WZ
//系统名称： 
//文件名称：Files.cs
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
	[Table("T_Files")]
	public partial class Files : IEntity    
	{
		#region Model
		/// <summary>
		/// 
		/// </summary>
		[Id]
		public int IFId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column(Length=2000)]
		public string CFullName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column(Length=2000)]
		public string CDir { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column(Length=1000)]
		public string CFileName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CExtention { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? IFileLength { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TCreateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TLastUpdateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? IStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TSysCheckDateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column(Length=2000)]
		public string CRemark { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column(Length=1000)]
		public string TKeyWords { get; set; }
		#endregion
	}
}
   