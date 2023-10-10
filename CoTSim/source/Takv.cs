// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: takv.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Atakmap.Commoncommo.Protobuf.V1 {

  /// <summary>Holder for reflection information generated from takv.proto</summary>
  public static partial class TakvReflection {

    #region Descriptor
    /// <summary>File descriptor for takv.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TakvReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cgp0YWt2LnByb3RvEh9hdGFrbWFwLmNvbW1vbmNvbW1vLnByb3RvYnVmLnYx",
            "IkUKBFRha3YSDgoGZGV2aWNlGAEgASgJEhAKCHBsYXRmb3JtGAIgASgJEgoK",
            "Am9zGAMgASgJEg8KB3ZlcnNpb24YBCABKAlCAkgDYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Atakmap.Commoncommo.Protobuf.V1.Takv), global::Atakmap.Commoncommo.Protobuf.V1.Takv.Parser, new[]{ "Device", "Platform", "Os", "Version" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// All items are required unless otherwise noted!
  /// "required" means if they are missing on send, the conversion
  /// to the message format will be rejected and fall back to opaque
  /// XML representation
  /// </summary>
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class Takv : pb::IMessage<Takv>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Takv> _parser = new pb::MessageParser<Takv>(() => new Takv());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Takv> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Atakmap.Commoncommo.Protobuf.V1.TakvReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Takv() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Takv(Takv other) : this() {
      device_ = other.device_;
      platform_ = other.platform_;
      os_ = other.os_;
      version_ = other.version_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Takv Clone() {
      return new Takv(this);
    }

    /// <summary>Field number for the "device" field.</summary>
    public const int DeviceFieldNumber = 1;
    private string device_ = "";
    /// <summary>
    /// device=
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Device {
      get { return device_; }
      set {
        device_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "platform" field.</summary>
    public const int PlatformFieldNumber = 2;
    private string platform_ = "";
    /// <summary>
    /// platform=
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Platform {
      get { return platform_; }
      set {
        platform_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "os" field.</summary>
    public const int OsFieldNumber = 3;
    private string os_ = "";
    /// <summary>
    /// os=
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Os {
      get { return os_; }
      set {
        os_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "version" field.</summary>
    public const int VersionFieldNumber = 4;
    private string version_ = "";
    /// <summary>
    /// version=
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Version {
      get { return version_; }
      set {
        version_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Takv);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Takv other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Device != other.Device) return false;
      if (Platform != other.Platform) return false;
      if (Os != other.Os) return false;
      if (Version != other.Version) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Device.Length != 0) hash ^= Device.GetHashCode();
      if (Platform.Length != 0) hash ^= Platform.GetHashCode();
      if (Os.Length != 0) hash ^= Os.GetHashCode();
      if (Version.Length != 0) hash ^= Version.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Device.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Device);
      }
      if (Platform.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Platform);
      }
      if (Os.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Os);
      }
      if (Version.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Version);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Device.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Device);
      }
      if (Platform.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Platform);
      }
      if (Os.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Os);
      }
      if (Version.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Version);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Device.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Device);
      }
      if (Platform.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Platform);
      }
      if (Os.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Os);
      }
      if (Version.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Version);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Takv other) {
      if (other == null) {
        return;
      }
      if (other.Device.Length != 0) {
        Device = other.Device;
      }
      if (other.Platform.Length != 0) {
        Platform = other.Platform;
      }
      if (other.Os.Length != 0) {
        Os = other.Os;
      }
      if (other.Version.Length != 0) {
        Version = other.Version;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Device = input.ReadString();
            break;
          }
          case 18: {
            Platform = input.ReadString();
            break;
          }
          case 26: {
            Os = input.ReadString();
            break;
          }
          case 34: {
            Version = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Device = input.ReadString();
            break;
          }
          case 18: {
            Platform = input.ReadString();
            break;
          }
          case 26: {
            Os = input.ReadString();
            break;
          }
          case 34: {
            Version = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code