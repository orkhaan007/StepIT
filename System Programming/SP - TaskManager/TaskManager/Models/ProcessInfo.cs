using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models;

public class ProcessInfo
{
    public int Id { get; set; }
    public string ProcessName { get; set; }
    public int HandleCount { get; set; }
    public int ThreadCount { get; set; }
    public string MachineName { get; set; }

    public ProcessInfo(int id, string name, int handleCount, int threadCount, string machineName)
    {
        Id = id;
        ProcessName = name;
        HandleCount = handleCount;
        ThreadCount = threadCount;
        MachineName = machineName;
    }
}
