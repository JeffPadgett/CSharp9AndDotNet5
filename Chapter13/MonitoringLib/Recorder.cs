﻿using System;
using System.Diagnostics;
using static System.Console;
using static System.Diagnostics.Process;

namespace Packt.Shared
{
    public static class Recorder
    {
        static Stopwatch timer = new Stopwatch();

        static long bytesPhysicalBefore = 0;
        static long bytesVirtualBefore = 0;

        public static void Start()
        {
            // force two garbage collections to release memory that is 
            // no longer referenced but has not been released yet
            // this is an advanced technique that you should almost never use in application code. 
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // store the current physial and virtual memory use
            bytesPhysicalBefore = GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = GetCurrentProcess().VirtualMemorySize64;
            timer.Restart();
        }

        public static void Stop()
        {
            timer.Stop();
            long bytesPhysicalAfter = GetCurrentProcess().WorkingSet64;
            long bytesVirtualAfter = GetCurrentProcess().VirtualMemorySize64;
            WriteLine($"{bytesPhysicalAfter - bytesPhysicalBefore:N0} physical bytes used");
            WriteLine($"{bytesVirtualAfter - bytesVirtualBefore} virtual bytes used");
            WriteLine($"{timer.Elapsed} time span ellapsed.");
            WriteLine($"{timer.ElapsedMilliseconds:N0} total milliseconds ellapsed.");
        }
    }
}
