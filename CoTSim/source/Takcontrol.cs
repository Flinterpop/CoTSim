// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: takcontrol.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Atakmap.Commoncommo.Protobuf.V1 {

  /// <summary>Holder for reflection information generated from takcontrol.proto</summary>
  public static partial class TakcontrolReflection {

    #region Descriptor
    /// <summary>File descriptor for takcontrol.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TakcontrolReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChB0YWtjb250cm9sLnByb3RvEh9hdGFrbWFwLmNvbW1vbmNvbW1vLnByb3Rv",
            "YnVmLnYxIlIKClRha0NvbnRyb2wSFwoPbWluUHJvdG9WZXJzaW9uGAEgASgN",
            "EhcKD21heFByb3RvVmVyc2lvbhgCIAEoDRISCgpjb250YWN0VWlkGAMgASgJ",
            "QgJIA2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Atakmap.Commoncommo.Protobuf.V1.TakControl), global::Atakmap.Commoncommo.Protobuf.V1.TakControl.Parser, new[]{ "MinProtoVersion", "MaxProtoVersion", "ContactUid" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// TAK Protocol control message
  /// This specifies to a recipient what versions
  /// of protocol elements this sender supports during
  /// decoding.
  /// </summary>
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class TakControl : pb::IMessage<TakControl>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<TakControl> _parser = new pb::MessageParser<TakControl>(() => new TakControl());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<TakControl> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Atakmap.Commoncommo.Protobuf.V1.TakcontrolReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TakControl() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TakControl(TakControl other) : this() {
      minProtoVersion_ = other.minProtoVersion_;
      maxProtoVersion_ = other.maxProtoVersion_;
      contactUid_ = other.contactUid_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TakControl Clone() {
      return new TakControl(this);
    }

    /// <summary>Field number for the "minProtoVersion" field.</summary>
    public const int MinProtoVersionFieldNumber = 1;
    private uint minProtoVersion_;
    /// <summary>
    /// Lowest TAK protocol version supported
    /// If not filled in (reads as 0), version 1 is assumed
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint MinProtoVersion {
      get { return minProtoVersion_; }
      set {
        minProtoVersion_ = value;
      }
    }

    /// <summary>Field number for the "maxProtoVersion" field.</summary>
    public const int MaxProtoVersionFieldNumber = 2;
    private uint maxProtoVersion_;
    /// <summary>
    /// Highest TAK protocol version supported
    /// If not filled in (reads as 0), version 1 is assumed
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint MaxProtoVersion {
      get { return maxProtoVersion_; }
      set {
        maxProtoVersion_ = value;
      }
    }

    /// <summary>Field number for the "contactUid" field.</summary>
    public const int ContactUidFieldNumber = 3;
    private string contactUid_ = "";
    /// <summary>
    /// UID of the sending contact. May be omitted if
    /// this message is paired in a TakMessage with a CotEvent
    /// and the CotEvent contains this information
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string ContactUid {
      get { return contactUid_; }
      set {
        contactUid_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as TakControl);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(TakControl other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MinProtoVersion != other.MinProtoVersion) return false;
      if (MaxProtoVersion != other.MaxProtoVersion) return false;
      if (ContactUid != other.ContactUid) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (MinProtoVersion != 0) hash ^= MinProtoVersion.GetHashCode();
      if (MaxProtoVersion != 0) hash ^= MaxProtoVersion.GetHashCode();
      if (ContactUid.Length != 0) hash ^= ContactUid.GetHashCode();
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
      if (MinProtoVersion != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(MinProtoVersion);
      }
      if (MaxProtoVersion != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(MaxProtoVersion);
      }
      if (ContactUid.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(ContactUid);
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
      if (MinProtoVersion != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(MinProtoVersion);
      }
      if (MaxProtoVersion != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(MaxProtoVersion);
      }
      if (ContactUid.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(ContactUid);
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
      if (MinProtoVersion != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(MinProtoVersion);
      }
      if (MaxProtoVersion != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(MaxProtoVersion);
      }
      if (ContactUid.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ContactUid);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(TakControl other) {
      if (other == null) {
        return;
      }
      if (other.MinProtoVersion != 0) {
        MinProtoVersion = other.MinProtoVersion;
      }
      if (other.MaxProtoVersion != 0) {
        MaxProtoVersion = other.MaxProtoVersion;
      }
      if (other.ContactUid.Length != 0) {
        ContactUid = other.ContactUid;
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
          case 8: {
            MinProtoVersion = input.ReadUInt32();
            break;
          }
          case 16: {
            MaxProtoVersion = input.ReadUInt32();
            break;
          }
          case 26: {
            ContactUid = input.ReadString();
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
          case 8: {
            MinProtoVersion = input.ReadUInt32();
            break;
          }
          case 16: {
            MaxProtoVersion = input.ReadUInt32();
            break;
          }
          case 26: {
            ContactUid = input.ReadString();
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
