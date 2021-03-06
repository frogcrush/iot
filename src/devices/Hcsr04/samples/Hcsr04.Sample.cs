﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading;
using Iot.Device.Hcsr04;
using UnitsNet;

namespace Iot.Device.Hcsr04.Samples
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Hcsr04 Sample!");

            using (var sonar = new Hcsr04(4, 17))
            {
                while (true)
                {
                    var res = sonar.TryGetDistance(out Length distance);
                    if (res)
                    {
                        Console.WriteLine($"Distance: {distance.Centimeters} cm");
                    }
                    else
                    {
                        Console.WriteLine("Error reading sensor");
                    }

                    Thread.Sleep(1000);
                }
            }
        }
    }
}