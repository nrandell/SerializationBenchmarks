// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: GoogleProtoPerson.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Benchmarks {

  /// <summary>Holder for reflection information generated from GoogleProtoPerson.proto</summary>
  public static partial class GoogleProtoPersonReflection {

    #region Descriptor
    /// <summary>File descriptor for GoogleProtoPerson.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GoogleProtoPersonReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChdHb29nbGVQcm90b1BlcnNvbi5wcm90bxIKQmVuY2htYXJrcxofZ29vZ2xl",
            "L3Byb3RvYnVmL3RpbWVzdGFtcC5wcm90byKtAQoMR29vZ2xlUGVyc29uEhAK",
            "CEZ1bGxOYW1lGAEgASgJEiwKCEJpcnRoZGF5GAIgASgLMhouZ29vZ2xlLnBy",
            "b3RvYnVmLlRpbWVzdGFtcBIwCgRUYWdzGAMgAygLMiIuQmVuY2htYXJrcy5H",
            "b29nbGVQZXJzb24uVGFnc0VudHJ5GisKCVRhZ3NFbnRyeRILCgNrZXkYASAB",
            "KAkSDQoFdmFsdWUYAiABKAk6AjgBYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Benchmarks.GooglePerson), global::Benchmarks.GooglePerson.Parser, new[]{ "FullName", "Birthday", "Tags" }, null, null, new pbr::GeneratedClrTypeInfo[] { null, })
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GooglePerson : pb::IMessage<GooglePerson> {
    private static readonly pb::MessageParser<GooglePerson> _parser = new pb::MessageParser<GooglePerson>(() => new GooglePerson());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GooglePerson> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Benchmarks.GoogleProtoPersonReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GooglePerson() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GooglePerson(GooglePerson other) : this() {
      fullName_ = other.fullName_;
      Birthday = other.birthday_ != null ? other.Birthday.Clone() : null;
      tags_ = other.tags_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GooglePerson Clone() {
      return new GooglePerson(this);
    }

    /// <summary>Field number for the "FullName" field.</summary>
    public const int FullNameFieldNumber = 1;
    private string fullName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FullName {
      get { return fullName_; }
      set {
        fullName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Birthday" field.</summary>
    public const int BirthdayFieldNumber = 2;
    private global::Google.Protobuf.WellKnownTypes.Timestamp birthday_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp Birthday {
      get { return birthday_; }
      set {
        birthday_ = value;
      }
    }

    /// <summary>Field number for the "Tags" field.</summary>
    public const int TagsFieldNumber = 3;
    private static readonly pbc::MapField<string, string>.Codec _map_tags_codec
        = new pbc::MapField<string, string>.Codec(pb::FieldCodec.ForString(10), pb::FieldCodec.ForString(18), 26);
    private readonly pbc::MapField<string, string> tags_ = new pbc::MapField<string, string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, string> Tags {
      get { return tags_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GooglePerson);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GooglePerson other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (FullName != other.FullName) return false;
      if (!object.Equals(Birthday, other.Birthday)) return false;
      if (!Tags.Equals(other.Tags)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (FullName.Length != 0) hash ^= FullName.GetHashCode();
      if (birthday_ != null) hash ^= Birthday.GetHashCode();
      hash ^= Tags.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (FullName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(FullName);
      }
      if (birthday_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Birthday);
      }
      tags_.WriteTo(output, _map_tags_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (FullName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(FullName);
      }
      if (birthday_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Birthday);
      }
      size += tags_.CalculateSize(_map_tags_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GooglePerson other) {
      if (other == null) {
        return;
      }
      if (other.FullName.Length != 0) {
        FullName = other.FullName;
      }
      if (other.birthday_ != null) {
        if (birthday_ == null) {
          birthday_ = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        Birthday.MergeFrom(other.Birthday);
      }
      tags_.Add(other.tags_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            FullName = input.ReadString();
            break;
          }
          case 18: {
            if (birthday_ == null) {
              birthday_ = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(birthday_);
            break;
          }
          case 26: {
            tags_.AddEntriesFrom(input, _map_tags_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code