
//-------------------------------------------------------------------

//版权所有：版权所有(C) 2016，CL
//系统名称： 
//文件名称：FileCategoryRelations.cs
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
	[Table("T_FileCategoryRelations")]
	public partial class FileCategoryRelations : IEntity    
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
		[Id]
		public int ICId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CRemark { get; set; }
		#endregion
	}
}
   