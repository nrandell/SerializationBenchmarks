using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics;
using BenchmarkDotNet.Diagnostics.Windows;
using Google.Protobuf.WellKnownTypes;
using Jil;
using Newtonsoft.Json;

namespace Benchmarks
{
    [Config(typeof(Config))]
    public class ProtobufVsBondVsJsonNetVsJilDeserialization
    {
        Person personToSerialize;
        byte[] personProtobuf;
        byte[] personBond;
        string personJsonNet;
        string personJsonJil;
        string personJsonNetBuffers;
        private GooglePerson googlePersonToSerialize;
        private byte[] personGoogleProtobuf;

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


            personBond = BenchmarksHelper.SerializeBond(personToSerialize);
            personProtobuf = BenchmarksHelper.SerializeProtobuf(personToSerialize);
            personGoogleProtobuf = BenchmarksHelper.SerializeGoogleProtobuf(googlePersonToSerialize);
            personJsonNet = JsonConvert.SerializeObject(personToSerialize);
            personJsonJil = Jil.JSON.Serialize(personToSerialize);
            personJsonNetBuffers = BenchmarksHelper.SerializeJsonNetBuffers(personToSerialize);
        }

        [Benchmark]
        public void ProtobufDeserialize()
        {
            BenchmarksHelper.DeserializeProtobuf<Person>(personProtobuf);
        }

        [Benchmark]
        public void GoogleProtobufDeserialize()
        {
            BenchmarksHelper.DeserializeGoogleProtobuf(personProtobuf);
        }

        [Benchmark]
        public void GoogleProtobufDeserializeByteArray()
        {
            BenchmarksHelper.DeserializeGoogleProtobufByteArray(personProtobuf);
        }

        [Benchmark]
        public void BondDeserialize()
        {
            BenchmarksHelper.DeserializeBond<Person>(personBond);
        }

        [Benchmark(Baseline = true)]
        public void JsonNetDeserialization()
        {
            JsonConvert.DeserializeObject<Person>(personJsonNet);
        }

        [Benchmark]
        public void JsonJilDeserialization()
        {
            JSON.Deserialize<Person>(personJsonJil);
        }

        [Benchmark]
        public void JsonNetWithBuffersDeserialization()
        {
            BenchmarksHelper.DeserializeJsonNetBuffers<Person>(personJsonNetBuffers);
        }
    }
}
