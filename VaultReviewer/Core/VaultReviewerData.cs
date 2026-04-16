using System;
using System.Collections.Generic;
using System.Text;

namespace VaultReviewer.Core
{
    public class VaultRegisters
    {
        public DateTime Date { get; set; }
        public string DocPath { get; set; }
        public bool IsReviewed { get; set; }
    }

    public class VaultReviewerData
    {
        public string VaultNamePath { get; set; }
        public List<VaultRegisters> ReviewedPathsHistory { get; set; }
        public List<VaultRegisters> RecentReviewedPaths { get; set; }
        public List<VaultRegisters> PathsToReviewToday { get; set; }

        public VaultReviewerData()
        {
            VaultNamePath = string.Empty;
            RecentReviewedPaths = new List<VaultRegisters>();
            PathsToReviewToday = new List<VaultRegisters>();
            ReviewedPathsHistory = new List<VaultRegisters>();
        }
    }
}
