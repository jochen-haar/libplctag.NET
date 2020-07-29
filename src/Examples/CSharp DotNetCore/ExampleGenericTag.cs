﻿using libplctag;
using libplctag.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CSharpDotNetCore
{
    class ExampleGenericTag
    {

        const int timeout = 1000;
        const string gateway = "10.10.10.10";
        const string path = "1,0";


        public static void Run()
        {

            //Bool - Test both cases
            var boolTag = new Tag<BoolMarshaller, bool>()
            {
                Name = "TestBOOL",
                Gateway = gateway,
                Path = path,
                PlcType = PlcType.ControlLogix
            };
            //Signed Numbers
            var sintTag = new Tag<SintMarshaller, sbyte>()
            {
                Name = "TestSINT",
                Gateway = gateway,
                Path = path,
                PlcType = PlcType.ControlLogix
            };
            var intTag = new Tag<IntMarshaller, short>()
            {
                Name = "TestINT",
                Gateway = gateway,
                Path = path,
                PlcType = PlcType.ControlLogix
            };
            var dintTag = new Tag<DintMarshaller, int>()
            {
                Name = "TestBOOL",
                Gateway = gateway,
                Path = path,
                PlcType = PlcType.ControlLogix
            };
            var lintTag = new Tag<LintMarshaller, long>()
            {
                Name = "TestLINT",
                Gateway = gateway,
                Path = path,
                PlcType = PlcType.ControlLogix
            };

            //Floating Points
            var realTag = new Tag<RealMarshaller, float>()
            {
                Name = "TestREAL",
                Gateway = gateway,
                Path = path,
                PlcType = PlcType.ControlLogix
            };


            boolTag.Initialize(timeout);
            boolTag.Read(timeout);

            sintTag.Initialize(timeout);
            sintTag.Read(timeout);

            intTag.Initialize(timeout);
            intTag.Read(timeout);

            dintTag.Initialize(timeout);
            dintTag.Read(timeout);

            lintTag.Initialize(timeout);
            lintTag.Read(timeout);

            realTag.Initialize(timeout);
            realTag.Read(timeout);



        }


        public static void StringArray()
        {

            var stringTag = new Tag<StringMarshaller, string>()
            {
                Name = "MY_STRING_1D[0]",
                Gateway = "192.168.0.10",
                Path = path,
                Protocol = Protocol.ab_eip,
                PlcType = PlcType.ControlLogix,
                ElementCount = 100
            };

            stringTag.Initialize(5000);

            var r = new Random((int)DateTime.Now.ToBinary());

            for (int ii = 0; ii < 100; ii++)
                stringTag.Value[ii] = r.Next().ToString();
            
            stringTag.Write(5000);

            Console.WriteLine("DONE");


        }

    }

}
