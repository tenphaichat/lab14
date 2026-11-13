using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Lab14_AdvancedReport.Reports
{
    /// <summary>
    /// Báo cáo sinh viên theo khoa có tham số pTenKhoa, pNgayLap (Bài 1, 2, 3, 5)
    /// </summary>
    public class CrystalReportSinhVienTheoKhoa : ReportClass
    {
        public CrystalReportSinhVienTheoKhoa() { }

        public override string ResourceName
        {
            get => "CrystalReportSinhVienTheoKhoa.rpt";
            set { }
        }

        public override bool NewGenerator
        {
            get => true;
            set { }
        }

        public override string FullResourceName
        {
            get => "Lab14_AdvancedReport.Reports.CrystalReportSinhVienTheoKhoa.rpt";
            set { }
        }
    }

    /// <summary>
    /// Báo cáo sinh viên theo khoảng điểm min/max (Bài 4)
    /// </summary>
    public class CrystalReportKhoangDiem : ReportClass
    {
        public CrystalReportKhoangDiem() { }

        public override string ResourceName
        {
            get => "CrystalReportKhoangDiem.rpt";
            set { }
        }

        public override bool NewGenerator
        {
            get => true;
            set { }
        }

        public override string FullResourceName
        {
            get => "Lab14_AdvancedReport.Reports.CrystalReportKhoangDiem.rpt";
            set { }
        }
    }

    /// <summary>
    /// Báo cáo Top N sinh viên tiêu biểu (Bài 6)
    /// </summary>
    public class CrystalReportTopN : ReportClass
    {
        public CrystalReportTopN() { }

        public override string ResourceName
        {
            get => "CrystalReportTopN.rpt";
            set { }
        }

        public override bool NewGenerator
        {
            get => true;
            set { }
        }

        public override string FullResourceName
        {
            get => "Lab14_AdvancedReport.Reports.CrystalReportTopN.rpt";
            set { }
        }
    }

    /// <summary>
    /// Báo cáo đăng ký học phần nhóm theo học kỳ (Bài 7)
    /// </summary>
    public class CrystalReportDangKyHocKy : ReportClass
    {
        public CrystalReportDangKyHocKy() { }

        public override string ResourceName
        {
            get => "CrystalReportDangKyHocKy.rpt";
            set { }
        }

        public override bool NewGenerator
        {
            get => true;
            set { }
        }

        public override string FullResourceName
        {
            get => "Lab14_AdvancedReport.Reports.CrystalReportDangKyHocKy.rpt";
            set { }
        }
    }
}
