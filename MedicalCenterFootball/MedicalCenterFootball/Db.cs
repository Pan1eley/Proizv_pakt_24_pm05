using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MedicalCenterFootball
{
    public static class Db
    {
        public static MedicalCenterEntities Conn = new MedicalCenterEntities();
    }
}
