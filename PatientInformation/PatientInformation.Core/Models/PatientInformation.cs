using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInformation.Core.Models
{
    public class PatientInformation
    {
        public int PatientInformationId { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedUtc { get; set; }

        /// <summary>
        /// 就诊时间
        /// </summary>

        public DateTime VisitingTime { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// 主诉
        /// </summary>
        public string ChiefComplaint { get; set; }

        /// <summary>
        /// 病史
        /// </summary>
        public string MedicalHistory { get; set; }

        /// <summary>
        /// 查体
        /// </summary>
        public string Check { get; set; }

        /// <summary>
        /// 诊断
        /// </summary>
        public string Diagnosis { get; set; }

        /// <summary>
        /// 治疗
        /// </summary>
        public string Treatment { get; set; }

        /// <summary>
        ///  联系地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 牙位 左
        /// </summary>
        public string TeethLeft { get; set; }

        /// <summary>
        /// 牙位 右
        /// </summary>
        public string TeethRight { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 完成日期
        /// </summary>
        public DateTime DoneTime { get; set; }

        /// <summary>
        /// M
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// 带入
        /// </summary>
        public bool Wear { get; set; }
    }
}
