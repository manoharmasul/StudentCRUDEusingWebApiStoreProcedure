namespace StudentCRUDEusingWebApiStoreProcedure.Model
{
    public class Student
    {
        //@srNo,@sName,@smobileNo,@batch,@marks,@grade,@isDeleted

        public int srNo { get; set; }
        public string sName { get; set; }
        public string smobileNo { get; set; }
        public string batch { get; set; }
        public double marks { get; set; }
        public string grade { get; set; }
        public int isDeleted { get; set; }

    }
}
