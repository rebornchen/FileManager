
//-------------------------------------------------------------------

//版权所有：版权所有(C) 2016，CL
//系统名称： 
//文件名称：RSSNEmail.cs
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
	[Table("RSSNEmail")]
	public partial class RSSNEmail : IEntity    
	{
		#region Model
		/// <summary>
		/// 
		/// </summary>
		public bool _Locked { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string SSNName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string SSNEmailAdd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int _Identify { get; set; }
		#endregion
        
	}
}
   