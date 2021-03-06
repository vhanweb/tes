﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class AdjustmentViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "OutletID")]
        public Nullable<int> OutletID { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy { get; set; }

        [Display(Name = "CreatedOn")]
        public Nullable<DateTime> CreatedOn { get; set; }

        [Display(Name = "ModifiedBy")]
        public Nullable<int> ModifiedBy { get; set; }

        [Display(Name = "ModifiedOn")]
        public Nullable<DateTime> ModifiedOn { get; set; }

        [Display(Name = "HeaderID")]
        public Nullable<int> HeaderID { get; set; }

        [Display(Name = "VariantID")]
        public List<int> VariantID { get; set; }

        [Display(Name = "InStock")]
        public List<int> InStock { get; set; }

        [Display(Name = "Adjusment")]
        public List<int> Adjusment { get; set; }

        [Display(Name = "Outlet Name")]
        public string OutletName { get; set; }

        public List<string> VariantName { get; set; }
        public List<int> AdjusmentList { get; set; }
        [Display(Name = "ActualStock")]

        public List<int> ActualStock { get; set; }

        public List<AdjustmentDetailViewModel> AdjustmentDetail { get; set; }

    }
}
