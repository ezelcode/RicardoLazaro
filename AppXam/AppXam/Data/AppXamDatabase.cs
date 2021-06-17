using AppXam.Common.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppXam.Data
{
    public class AppXamDatabase
    {
        readonly SQLiteAsyncConnection database;

        public AppXamDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<WorkTask>().Wait();
        }

        public Task<List<WorkTask>> GetWorkTasksAsync()
        {
            //Get all WorkTasks.
            return database.Table<WorkTask>().ToListAsync();
        }

        public Task<WorkTask> GetWorkTaskAsync(int id)
        {
            // Get a specific WorkTask.
            return database.Table<WorkTask>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveWorkTaskAsync(WorkTask workTask)
        {
            if (workTask.Id != 0)
            {
                // Update an existing WorkTask.
                return database.UpdateAsync(workTask);
            }
            else
            {
                // Save a new WorkTask.
                return database.InsertAsync(workTask);
            }
        }

        public Task<int> DeleteWorkTaskAsync(WorkTask workTask)
        {
            // Delete a WorkTask.
            return database.DeleteAsync(workTask);
        }
    }
}
