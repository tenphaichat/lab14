using System;
using System.Collections.Generic;
using System.Data;
using Lab14_AdvancedReport.DAL;
using Lab14_AdvancedReport.DTO;

namespace Lab14_AdvancedReport.BUS
{
    public class BaoCaoBUS
    {
        private readonly BaoCaoDAL _dal;

        public BaoCaoBUS()
        {
            _dal = new BaoCaoDAL();
        }

        public DataTable GetStudentsByDepartment(string maKhoa = null)
        {
            return _dal.GetStudentsByDepartment(maKhoa);
        }

        public DataTable GetByScoreRange(decimal min, decimal max, string maKhoa = null)
        {
            if (min < 0 || min > 10 || max < 0 || max > 10)
            {
                throw new ArgumentException("Điểm số phải nằm trong khoảng từ 0.0 đến 10.0.");
            }
            if (min > max)
            {
                throw new ArgumentException("Điểm tối thiểu (Min) không được lớn hơn điểm tối đa (Max).");
            }
            return _dal.GetByScoreRange(min, max, maKhoa);
        }

        public DataTable GetTopStudents(int topN, string maKhoa = null)
        {
            if (topN <= 0)
            {
                topN = 5;
            }
            return _dal.GetTopStudents(topN, maKhoa);
        }

        public DataTable GetRegistrationBySemester(int? hocKy = null)
        {
            return _dal.GetRegistrationBySemester(hocKy);
        }

        public DataTable GetRegistrationDetails(int? hocKy = null)
        {
            return _dal.GetRegistrationDetails(hocKy);
        }

        public DataTable GetDepartmentStatistics()
        {
            return _dal.GetDepartmentStatistics();
        }

        public DataTable GetGradeDistribution()
        {
            return _dal.GetGradeDistribution();
        }

        public DataTable GetAllKhoa()
        {
            return _dal.GetAllKhoa();
        }
    }
}
