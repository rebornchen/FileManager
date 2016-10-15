using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CL.Model;

namespace CL.Test
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// 测试数据库连接
        /// </summary>
        [TestMethod]
        public void TestSQLiteConnection()
        {
            CL.BLL.RegionBiz biz = new CL.BLL.RegionBiz();
            List<Region> list = biz.GetAll();

            Region model = list.Find(r => r.RegionID == 3);


            Assert.AreEqual(4, list.Count);
            Assert.AreEqual("Northern", model.RegionDescription.Trim());
        }
    }
}
