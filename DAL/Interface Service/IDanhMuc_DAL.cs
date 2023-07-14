using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAL
{

    public interface IDanhMuc_DAL
    {
        int Insert(string className, string monitorName, string teacherName);
        //int Delete(int classID);
        //int Update(int classID, string className, string monitorName, string teacherName);
        //DataTable getAll();
        //DataTable getClass_ID(int classID);
        //int getclassID_Last();
        //int checkClass_ID(int classID);
    }
    
}
