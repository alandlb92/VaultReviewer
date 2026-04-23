using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

using VaultReviewer.Forms;

namespace VaultReviewer.Core
{
    public class VaultReviewer
    {
        public VaultReviewerData mData;        
        private const string DataFileName = "data.json";
        private const string ConfigFileName = "config.json";
        private ReviewDashboard mMainForm;
        private int ReviewsPerDay = 2;
        private string UserName = "";
        private List<string> IgnoredPaths = new();

        public VaultReviewer(ReviewDashboard mainForm)
        {
            mMainForm = mainForm;
            LoadConfig();
            LoadData();
        }

        public List<String> ScanVault()
        {
            return Directory.GetFiles(mData.VaultNamePath, "*.md*", SearchOption.AllDirectories)
                .Where(f => !IsIgnored(f))
                .ToList();
        }

        private bool IsIgnored(string filePath)
        {
            foreach (var ignored in IgnoredPaths)
            {
                if (Directory.Exists(ignored))
                {
                    string dir = ignored.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                                + Path.DirectorySeparatorChar;
                    if (filePath.StartsWith(dir, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
                else if (filePath.Equals(ignored, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public void DrawReviews()
        {
            if (mData.PathsToReviewToday.Count == 0 || mData.PathsToReviewToday[0].Date != DateTime.Now.Date)
            {
                foreach (var review in mData.PathsToReviewToday)
                {
                    if(review.IsReviewed)
                    {
                        mData.RecentReviewedPaths.Add(review);
                        mData.ReviewedPathsHistory.Add(review);
                    }
                }
                
                mData.PathsToReviewToday.Clear();
                for (int i = 0; i < ReviewsPerDay; i++)
                {
                    mData.PathsToReviewToday.Add(DrawNewReview());
                }

                SaveData();
            }

            mMainForm.PopulateReviews(mData);
        }

        List<String> GetPathsOptions()
        {
            List<VaultRegisters> regs = new List<VaultRegisters>();
            regs.AddRange(mData.PathsToReviewToday);
            regs.AddRange(mData.RecentReviewedPaths);
            return ScanVault().Where(x => !regs.Any(y => y.DocPath == x)).ToList();
        }

        public VaultRegisters DrawNewReview()
        {
            List<String> pathOptions = GetPathsOptions();
            if (pathOptions.Count == 0)
            {
                mData.RecentReviewedPaths.Clear();
                pathOptions = GetPathsOptions();
            }

            Random rnd = new Random();
            int number = rnd.Next(0, pathOptions.Count);
            return new VaultRegisters { Date = DateTime.Now.Date, DocPath = pathOptions[number] };            
        }

        public string GetDataFolderPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "VaultReviewer"); ;
        }

        public string GetDataFilePath()
        {
            return Path.Combine(GetDataFolderPath(), DataFileName);
        }

        public string GetConfigFilePath()
        {
            return Path.Combine(GetDataFolderPath(), ConfigFileName);
        }

        private void CreateConfigFile()
        {
            Directory.CreateDirectory(GetDataFolderPath());
            Config config = new Config();
            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(GetConfigFilePath(), json);
            LoadConfig();
        }

        public void SaveConfig(int reviewsPerDay, string userName)
        {
            ReviewsPerDay = reviewsPerDay;
            UserName = userName;
            Config config = new Config { ReviewsPerDay = reviewsPerDay, UserName = userName, IgnoredPaths = IgnoredPaths };
            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(GetConfigFilePath(), json);
        }

        public void SaveIgnoredPaths(List<string> paths)
        {
            IgnoredPaths = paths;
            Config config = new Config { ReviewsPerDay = ReviewsPerDay, UserName = UserName, IgnoredPaths = IgnoredPaths };
            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(GetConfigFilePath(), json);
        }

        public int GetReviewsPerDay() => ReviewsPerDay;
        public string GetUserName() => UserName;
        public List<string> GetIgnoredPaths() => new List<string>(IgnoredPaths);
        public string GetDisplayTitle() => string.IsNullOrWhiteSpace(UserName) ? "Homework" : $"{UserName}'s Homework";

        private void LoadConfig()
        {
            if (File.Exists(GetConfigFilePath()))
            {
                //Just load data
                string path = GetConfigFilePath();
                string json = File.ReadAllText(GetConfigFilePath());
                Config config = JsonSerializer.Deserialize<Config>(json);
                if (config != null)
                {
                    ReviewsPerDay = config.ReviewsPerDay;
                    UserName = config.UserName ?? "";
                    IgnoredPaths = config.IgnoredPaths ?? new();
                }
                else
                {
                    MessageBox.Show("Something wrong when loading the config, the config file will be regenerated");
                    File.Delete(GetConfigFilePath());
                    CreateConfigFile();
                }
            }
            else
            {
                CreateConfigFile();
            }
        }

        private void LoadData()
        {
            if (File.Exists(GetDataFilePath()))
            {
                //Just load data
                string json = File.ReadAllText(GetDataFilePath());
                if (string.IsNullOrEmpty(json))
                {
                    MessageBox.Show("Data file is empty. Please set the vault path again.");
                    return;
                }

                mData = JsonSerializer.Deserialize<VaultReviewerData>(json);
                DrawReviews();
            }
            else
            {
                Directory.CreateDirectory(GetDataFolderPath());
                mMainForm.SetVaultPath(OnVaultIsSeted);           
            }
        }

        private void OnVaultIsSeted(string vaultPath)
        {
            mData = new VaultReviewerData();
            mData.VaultNamePath = vaultPath;
            SaveData();
            DrawReviews();
        }

        private void SaveData()
        {
            string json = JsonSerializer.Serialize(mData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(GetDataFilePath(), json);
        }

        public void MarkAsreviwed(int indexReviwed, bool markAsReviwed)
        {
            mData.PathsToReviewToday[indexReviwed].IsReviewed = markAsReviwed;
            SaveData();
        }
    }
}
