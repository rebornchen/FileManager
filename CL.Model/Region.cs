using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL.Model.Interfaces;
using NLite.Data;

namespace CL.Model
{
    [Serializable]
    [Table("Region")]
    public class Region : IEntity
    {

        #region Model
        /// <summary>
        /// 
        /// </summary>
        public int? RegionID { get; set; }

        public string RegionDescription { get; set; }

        #endregion

    }
}
