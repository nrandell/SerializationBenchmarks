﻿using System;
using System.Buffers;
using System.IO;
using System.Text;
using Bond;
using Bond.IO.Unsafe;
using Bond.Protocols;
using Newtonsoft.Json;
using ProtoBuf;
using Google.Protobuf;
namespace Benchmarks
{
    public static class BenchmarksHelper
    {
        private static ArrayPool<byte> bytePool = ArrayPool<byte>.Shared;
        private static JsonSerializer serializer = JsonSerializer.CreateDefault();

        public static byte[] SerializeBond<T>(T value)
        {
            byte[] buffer = bytePool.Rent(128);
            var outputBuffer = new OutputBuffer(buffer);
            var compactWriter = new CompactBinaryWriter<OutputBuffer>(outputBuffer);
            Serialize.To(compactWriter, value);
            var result = new byte[outputBuffer.Data.Count];
            Buffer.BlockCopy(buffer, outputBuffer.Data.Offset, result, 0, result.Length);
            bytePool.Return(buffer);
            return result;
        }

        public static byte[] SerializeProtobuf<T>(T value)
        {
            byte[] buffer = bytePool.Rent(128);
            using (var stream = new MemoryStream(buffer))
            {
                Serializer.Serialize(stream, value);
                var result = new byte[stream.Position];
                Buffer.BlockCopy(buffer, 0, result, 0, result.Length);
                bytePool.Return(buffer);
                return result;
            }
        }

        public static byte[] SerializeGoogleProtobuf(IMessage value)
        {
            byte[] buffer = bytePool.Rent(128);
            using (var stream = new MemoryStream(buffer))
            {
                value.WriteTo(stream);
                var result = new byte[stream.Position];
                Buffer.BlockCopy(buffer, 0, result, 0, result.Length);
                bytePool.Return(buffer);
                return result;
            }
        }

        public static byte[] SerializeGoogleProtobufCodedStream(IMessage value)
        {
            byte[] buffer = bytePool.Rent(128);
            using (var stream = new CodedOutputStream(buffer))
            {
                value.WriteTo(stream);
                var result = new byte[stream.Position];
                Buffer.BlockCopy(buffer, 0, result, 0, result.Length);
                bytePool.Return(buffer);
                return result;
            }
        }



        public static string SerializeJsonNetBuffers(object value)
        {
            using (var stringWriter = new StringWriter(new StringBuilder(256)))
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.ArrayPool = CharArrayPool.Instance;
                    serializer.Serialize(jsonTextWriter, value);
                    jsonTextWriter.Flush();
                    return stringWriter.GetStringBuilder().ToString();
                }
            }
        }

        public static T DeserializeJsonNetBuffers<T>(string value)
        {
            using (var stringReader = new StringReader(value))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    jsonTextReader.ArrayPool = CharArrayPool.Instance;
                    var result = serializer.Deserialize<T>(jsonTextReader);
                    return result;
                }
            }
        }

        public static T DeserializeBond<T>(byte[] value)
        {
            var inputBuffer = new InputBuffer(value);
            var compactReader = new CompactBinaryReader<InputBuffer>(inputBuffer);
            return Deserialize<T>.From(compactReader);
        }

        public static T DeserializeProtobuf<T>(byte[] value)
        {
            using (var valueBytes = new MemoryStream(value))
            {
                return Serializer.Deserialize<T>(valueBytes);
            }
        }

        public static GooglePerson DeserializeGoogleProtobufByteArray(byte[] value)
        {
            return GooglePerson.Parser.ParseFrom(value);
        }

        public static GooglePerson DeserializeGoogleProtobuf(byte[] value)
        {
            using (var valueBytes = new MemoryStream(value))
            {
                return GooglePerson.Parser.ParseFrom(valueBytes);
            }
        }

    }
}
