using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics;
using BenchmarkDotNet.Diagnostics.Windows;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Jil;
using Newtonsoft.Json;

namespace Benchmarks
{
    [Config(typeof(Config))]
    public class ProtobufVsBondVsJsonNetVsJilSerialization
    {
        Person personToSerialize;
        GooglePerson googlePersonToSerialize;

        private class Config : ManualConfig
        {
            public Config()
            {
                Add(new MemoryDiagnoser());
            }
        }

        [Setup]
        public void Setup()
        {
            personToSerialize = new Person() {
                FullName = "Stefán Jökull Sigurðarson",
                Birthday = new DateTime(1979, 11, 23, 0, 0, 0, DateTimeKind.Utc),
                Tags = new Dictionary<string, string>
                {
                    { "Interest1", "Judo" },
                    { "Interest2", "Music" }
                }
            };

            googlePersonToSerialize = new GooglePerson {
                FullName = personToSerialize.FullName,
                Birthday = Timestamp.FromDateTime(personToSerialize.Birthday)
            };
            googlePersonToSerialize.Tags.Add(personToSerialize.Tags);

        }

        [Benchmark]
        public void GoogleProtobufSerialize()
        {
            BenchmarksHelper.SerializeGoogleProtobuf(googlePersonToSerialize);
        }

        [Benchmark]
        public void GoogleProtobufSerializeCodedStream()
        {
            BenchmarksHelper.SerializeGoogleProtobufCodedStream(googlePersonToSerialize);
        }

        [Benchmark]
        public void ProtobufSerialize()
        {
            BenchmarksHelper.SerializeProtobuf(personToSerialize);
        }

        [Benchmark]
        public void BondSerialize()
        {
            BenchmarksHelper.SerializeBond(personToSerialize);
        }

        [Benchmark(Baseline = true)]
        public void JsonNetSerialization()
        {
            JsonConvert.SerializeObject(personToSerialize);
        }

        [Benchmark]
        public void JsonNetSerializationWithBuffers()
        {
            BenchmarksHelper.SerializeJsonNetBuffers(personToSerialize);
        }

        [Benchmark]
        public void JsonJilSerialization()
        {
            JSON.Serialize(personToSerialize);
        }
    }
}
