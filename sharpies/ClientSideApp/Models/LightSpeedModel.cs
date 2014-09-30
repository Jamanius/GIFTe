using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;
using Mindscape.LightSpeed.Linq;

namespace ClientSideApp.Models
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [System.Runtime.Serialization.DataContract]
  [Table("Customers", IdentityMethod=IdentityMethod.KeyTable)]
  public partial class Customer : Entity<int>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _name;
    [ValidateLength(0, 50)]
    private string _phone_number;
    [ValidateLength(0, 300)]
    private string _email;
    [ValueField]
    private Microsoft.SqlServer.Types.SqlGeography _location;

    #pragma warning disable 649  // "Field is never assigned to" - LightSpeed assigns these fields internally
    [System.Runtime.Serialization.DataMember]
    private System.DateTime _createdOn;
    [System.Runtime.Serialization.DataMember]
    private System.DateTime _updatedOn;
    [System.Runtime.Serialization.DataMember]
    private System.Nullable<System.DateTime> _deletedOn;
    #pragma warning restore 649    

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Name entity attribute.</summary>
    public const string NameField = "Name";
    /// <summary>Identifies the Phone_number entity attribute.</summary>
    public const string Phone_numberField = "Phone_number";
    /// <summary>Identifies the Email entity attribute.</summary>
    public const string EmailField = "Email";
    /// <summary>Identifies the Location entity attribute.</summary>
    public const string LocationField = "Location";
    /// <summary>Identifies the CreatedOn entity attribute.</summary>
    public const string CreatedOnField = "CreatedOn";
    /// <summary>Identifies the UpdatedOn entity attribute.</summary>
    public const string UpdatedOnField = "UpdatedOn";
    /// <summary>Identifies the DeletedOn entity attribute.</summary>
    public const string DeletedOnField = "DeletedOn";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Customer")]
    private EntityCollection<Note> _notes = new EntityCollection<Note>();
    [ReverseAssociation("Customer")]
    private EntityCollection<Gift> _gifts = new EntityCollection<Gift>();
    [ReverseAssociation("CustomerFrom")]
    private EntityCollection<Transaction> _transactionsByCustomerFrom = new EntityCollection<Transaction>();
    [ReverseAssociation("CustomerTo")]
    private EntityCollection<Transaction> _transactionsByCustomerTo = new EntityCollection<Transaction>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<Note> Notes
    {
      get { return Get(_notes); }
      set { _notes = value; }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<Gift> Gifts
    {
      get { return Get(_gifts); }
      set { _gifts = value; }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<Transaction> TransactionsByCustomerFrom
    {
      get { return Get(_transactionsByCustomerFrom); }
      set { _transactionsByCustomerFrom = value; }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<Transaction> TransactionsByCustomerTo
    {
      get { return Get(_transactionsByCustomerTo); }
      set { _transactionsByCustomerTo = value; }
    }


    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public string Name
    {
      get { return Get(ref _name, "Name"); }
      set { Set(ref _name, value, "Name"); }
    }

    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public string Phone_number
    {
      get { return Get(ref _phone_number, "Phone_number"); }
      set { Set(ref _phone_number, value, "Phone_number"); }
    }

    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public string Email
    {
      get { return Get(ref _email, "Email"); }
      set { Set(ref _email, value, "Email"); }
    }

    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public Microsoft.SqlServer.Types.SqlGeography Location
    {
      get { return Get(ref _location, "Location"); }
      set { Set(ref _location, value, "Location"); }
    }
    /// <summary>Gets the time the entity was created</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.DateTime CreatedOn
    {
      get { return _createdOn; }   
    }

    /// <summary>Gets the time the entity was last updated</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.DateTime UpdatedOn
    {
      get { return _updatedOn; }   
    }

    /// <summary>Gets the time the entity was soft-deleted</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DeletedOn
    {
      get { return _deletedOn; }   
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [System.Runtime.Serialization.DataContract]
  [Table("Notes", IdentityMethod=IdentityMethod.KeyTable)]
  public partial class Note : Entity<int>
  {
    #region Fields
  
    [ValidatePresence]
    private string _text;
    private int _customerId;

    #pragma warning disable 649  // "Field is never assigned to" - LightSpeed assigns these fields internally
    [System.Runtime.Serialization.DataMember]
    private System.DateTime _createdOn;
    [System.Runtime.Serialization.DataMember]
    private System.DateTime _updatedOn;
    [System.Runtime.Serialization.DataMember]
    private System.Nullable<System.DateTime> _deletedOn;
    #pragma warning restore 649    

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Text entity attribute.</summary>
    public const string TextField = "Text";
    /// <summary>Identifies the CustomerId entity attribute.</summary>
    public const string CustomerIdField = "CustomerId";
    /// <summary>Identifies the CreatedOn entity attribute.</summary>
    public const string CreatedOnField = "CreatedOn";
    /// <summary>Identifies the UpdatedOn entity attribute.</summary>
    public const string UpdatedOnField = "UpdatedOn";
    /// <summary>Identifies the DeletedOn entity attribute.</summary>
    public const string DeletedOnField = "DeletedOn";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Notes")]
    private readonly EntityHolder<Customer> _customer = new EntityHolder<Customer>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public Customer Customer
    {
      get { return Get(_customer); }
      set { Set(_customer, value); }
    }


    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public string Text
    {
      get { return Get(ref _text, "Text"); }
      set { Set(ref _text, value, "Text"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Customer" /> property.</summary>
    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public int CustomerId
    {
      get { return Get(ref _customerId, "CustomerId"); }
      set { Set(ref _customerId, value, "CustomerId"); }
    }
    /// <summary>Gets the time the entity was created</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.DateTime CreatedOn
    {
      get { return _createdOn; }   
    }

    /// <summary>Gets the time the entity was last updated</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.DateTime UpdatedOn
    {
      get { return _updatedOn; }   
    }

    /// <summary>Gets the time the entity was soft-deleted</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DeletedOn
    {
      get { return _deletedOn; }   
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [System.Runtime.Serialization.DataContract]
  [Table(IdentityMethod=IdentityMethod.KeyTable)]
  public partial class Gift : Entity<int>
  {
    #region Fields
  
    [Indexed]
    private string _title;
    [Indexed]
    private string _description;
    private string _comments;
    private string _gift_type;
    [ValueField]
    private Microsoft.SqlServer.Types.SqlGeography _location;
    private string _image;
    private string _status;
    private System.Nullable<double> _latitude;
    private System.Nullable<double> _longitude;
    private System.Nullable<int> _customerId;

    #pragma warning disable 649  // "Field is never assigned to" - LightSpeed assigns these fields internally
    [System.Runtime.Serialization.DataMember]
    private System.DateTime _createdOn;
    [System.Runtime.Serialization.DataMember]
    private System.DateTime _updatedOn;
    [System.Runtime.Serialization.DataMember]
    private System.Nullable<System.DateTime> _deletedOn;
    #pragma warning restore 649    

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the title entity attribute.</summary>
    public const string titleField = "title";
    /// <summary>Identifies the description entity attribute.</summary>
    public const string descriptionField = "description";
    /// <summary>Identifies the comments entity attribute.</summary>
    public const string commentsField = "comments";
    /// <summary>Identifies the gift_type entity attribute.</summary>
    public const string gift_typeField = "gift_type";
    /// <summary>Identifies the location entity attribute.</summary>
    public const string locationField = "location";
    /// <summary>Identifies the image entity attribute.</summary>
    public const string imageField = "image";
    /// <summary>Identifies the status entity attribute.</summary>
    public const string statusField = "status";
    /// <summary>Identifies the Latitude entity attribute.</summary>
    public const string LatitudeField = "Latitude";
    /// <summary>Identifies the Longitude entity attribute.</summary>
    public const string LongitudeField = "Longitude";
    /// <summary>Identifies the CustomerId entity attribute.</summary>
    public const string CustomerIdField = "CustomerId";
    /// <summary>Identifies the CreatedOn entity attribute.</summary>
    public const string CreatedOnField = "CreatedOn";
    /// <summary>Identifies the UpdatedOn entity attribute.</summary>
    public const string UpdatedOnField = "UpdatedOn";
    /// <summary>Identifies the DeletedOn entity attribute.</summary>
    public const string DeletedOnField = "DeletedOn";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Gift")]
    private EntityCollection<Transaction> _transactions = new EntityCollection<Transaction>();
    [ReverseAssociation("Gifts")]
    private readonly EntityHolder<Customer> _customer = new EntityHolder<Customer>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<Transaction> Transactions
    {
      get { return Get(_transactions); }
      set { _transactions = value; }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public Customer Customer
    {
      get { return Get(_customer); }
      set { Set(_customer, value); }
    }


    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public string title
    {
      get { return Get(ref _title, "title"); }
      set { Set(ref _title, value, "title"); }
    }

    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public string description
    {
      get { return Get(ref _description, "description"); }
      set { Set(ref _description, value, "description"); }
    }

    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public string comments
    {
      get { return Get(ref _comments, "comments"); }
      set { Set(ref _comments, value, "comments"); }
    }

    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public string gift_type
    {
      get { return Get(ref _gift_type, "gift_type"); }
      set { Set(ref _gift_type, value, "gift_type"); }
    }

    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public Microsoft.SqlServer.Types.SqlGeography location
    {
      get { return Get(ref _location, "location"); }
      set { Set(ref _location, value, "location"); }
    }

    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public string image
    {
      get { return Get(ref _image, "image"); }
      set { Set(ref _image, value, "image"); }
    }

    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public string status
    {
      get { return Get(ref _status, "status"); }
      set { Set(ref _status, value, "status"); }
    }

    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<double> Latitude
    {
      get { return Get(ref _latitude, "Latitude"); }
      set { Set(ref _latitude, value, "Latitude"); }
    }

    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<double> Longitude
    {
      get { return Get(ref _longitude, "Longitude"); }
      set { Set(ref _longitude, value, "Longitude"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Customer" /> property.</summary>
    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<int> CustomerId
    {
      get { return Get(ref _customerId, "CustomerId"); }
      set { Set(ref _customerId, value, "CustomerId"); }
    }
    /// <summary>Gets the time the entity was created</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.DateTime CreatedOn
    {
      get { return _createdOn; }   
    }

    /// <summary>Gets the time the entity was last updated</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.DateTime UpdatedOn
    {
      get { return _updatedOn; }   
    }

    /// <summary>Gets the time the entity was soft-deleted</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DeletedOn
    {
      get { return _deletedOn; }   
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [System.Runtime.Serialization.DataContract]
  [Table("Transactions")]
  public partial class Transaction : Entity<int>
  {
    #region Fields
  
    private int _status;
    [Column("CustomerFrom")]
    private int _customerFromId;
    [Column("CustomerTo")]
    private int _customerToId;
    private int _giftId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Status entity attribute.</summary>
    public const string StatusField = "Status";
    /// <summary>Identifies the CustomerFromId entity attribute.</summary>
    public const string CustomerFromIdField = "CustomerFromId";
    /// <summary>Identifies the CustomerToId entity attribute.</summary>
    public const string CustomerToIdField = "CustomerToId";
    /// <summary>Identifies the GiftId entity attribute.</summary>
    public const string GiftIdField = "GiftId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("TransactionsByCustomerFrom")]
    private readonly EntityHolder<Customer> _customerFrom = new EntityHolder<Customer>();
    [ReverseAssociation("TransactionsByCustomerTo")]
    private readonly EntityHolder<Customer> _customerTo = new EntityHolder<Customer>();
    [ReverseAssociation("Transactions")]
    private readonly EntityHolder<Gift> _gift = new EntityHolder<Gift>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public Customer CustomerFrom
    {
      get { return Get(_customerFrom); }
      set { Set(_customerFrom, value); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public Customer CustomerTo
    {
      get { return Get(_customerTo); }
      set { Set(_customerTo, value); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public Gift Gift
    {
      get { return Get(_gift); }
      set { Set(_gift, value); }
    }


    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public int Status
    {
      get { return Get(ref _status, "Status"); }
      set { Set(ref _status, value, "Status"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="CustomerFrom" /> property.</summary>
    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public int CustomerFromId
    {
      get { return Get(ref _customerFromId, "CustomerFromId"); }
      set { Set(ref _customerFromId, value, "CustomerFromId"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="CustomerTo" /> property.</summary>
    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public int CustomerToId
    {
      get { return Get(ref _customerToId, "CustomerToId"); }
      set { Set(ref _customerToId, value, "CustomerToId"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Gift" /> property.</summary>
    [System.Runtime.Serialization.DataMember]
    [System.Diagnostics.DebuggerNonUserCode]
    public int GiftId
    {
      get { return Get(ref _giftId, "GiftId"); }
      set { Set(ref _giftId, value, "GiftId"); }
    }

    #endregion
  }




  /// <summary>
  /// Provides a strong-typed unit of work for working with the LightSpeedModel model.
  /// </summary>
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  public partial class LightSpeedModelUnitOfWork : Mindscape.LightSpeed.UnitOfWork
  {

    public System.Linq.IQueryable<Customer> Customers
    {
      get { return this.Query<Customer>(); }
    }
    
    public System.Linq.IQueryable<Note> Notes
    {
      get { return this.Query<Note>(); }
    }
    
    public System.Linq.IQueryable<Gift> Gifts
    {
      get { return this.Query<Gift>(); }
    }
    
    public System.Linq.IQueryable<Transaction> Transactions
    {
      get { return this.Query<Transaction>(); }
    }
    
  }

#if LS3_DTOS

  namespace Contracts.Data
  {
    [System.Runtime.Serialization.DataContract(Name="LightSpeedModelDtoBase")]
    [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
    public partial class LightSpeedModelDtoBase
    {
    }

    [System.Runtime.Serialization.DataContract(Name="Customer")]
    [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
    public partial class CustomerDto : LightSpeedModelDtoBase
    {
      [System.Runtime.Serialization.DataMember]
      public string Name { get; set; }
      [System.Runtime.Serialization.DataMember]
      public string Phone_number { get; set; }
      [System.Runtime.Serialization.DataMember]
      public string Email { get; set; }
      [System.Runtime.Serialization.DataMember]
      public Microsoft.SqlServer.Types.SqlGeography Location { get; set; }
    }

    [System.Runtime.Serialization.DataContract(Name="Note")]
    [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
    public partial class NoteDto : LightSpeedModelDtoBase
    {
      [System.Runtime.Serialization.DataMember]
      public string Text { get; set; }
      [System.Runtime.Serialization.DataMember]
      public int CustomerId { get; set; }
    }

    [System.Runtime.Serialization.DataContract(Name="Gift")]
    [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
    public partial class GiftDto : LightSpeedModelDtoBase
    {
      [System.Runtime.Serialization.DataMember]
      public string title { get; set; }
      [System.Runtime.Serialization.DataMember]
      public string description { get; set; }
      [System.Runtime.Serialization.DataMember]
      public string comments { get; set; }
      [System.Runtime.Serialization.DataMember]
      public string gift_type { get; set; }
      [System.Runtime.Serialization.DataMember]
      public Microsoft.SqlServer.Types.SqlGeography location { get; set; }
      [System.Runtime.Serialization.DataMember]
      public string image { get; set; }
      [System.Runtime.Serialization.DataMember]
      public string status { get; set; }
      [System.Runtime.Serialization.DataMember]
      public System.Nullable<double> Latitude { get; set; }
      [System.Runtime.Serialization.DataMember]
      public System.Nullable<double> Longitude { get; set; }
      [System.Runtime.Serialization.DataMember]
      public System.Nullable<int> CustomerId { get; set; }
    }

    [System.Runtime.Serialization.DataContract(Name="Transaction")]
    [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
    public partial class TransactionDto : LightSpeedModelDtoBase
    {
      [System.Runtime.Serialization.DataMember]
      public int Status { get; set; }
      [System.Runtime.Serialization.DataMember]
      public int CustomerFromId { get; set; }
      [System.Runtime.Serialization.DataMember]
      public int CustomerToId { get; set; }
      [System.Runtime.Serialization.DataMember]
      public int GiftId { get; set; }
    }


    
    [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
    public static partial class LightSpeedModelDtoExtensions
    {
      static partial void CopyLightSpeedModelDtoBase(Entity entity, LightSpeedModelDtoBase dto);
      static partial void CopyLightSpeedModelDtoBase(LightSpeedModelDtoBase dto, Entity entity);

      static partial void BeforeCopyCustomer(Customer entity, CustomerDto dto);
      static partial void AfterCopyCustomer(Customer entity, CustomerDto dto);
      static partial void BeforeCopyCustomer(CustomerDto dto, Customer entity);
      static partial void AfterCopyCustomer(CustomerDto dto, Customer entity);
      
      private static void CopyCustomer(Customer entity, CustomerDto dto)
      {
        BeforeCopyCustomer(entity, dto);
        CopyLightSpeedModelDtoBase(entity, dto);
        dto.Name = entity.Name;
        dto.Phone_number = entity.Phone_number;
        dto.Email = entity.Email;
        dto.Location = entity.Location;
        AfterCopyCustomer(entity, dto);
      }
      
      private static void CopyCustomer(CustomerDto dto, Customer entity)
      {
        BeforeCopyCustomer(dto, entity);
        CopyLightSpeedModelDtoBase(dto, entity);
        entity.Name = dto.Name;
        entity.Phone_number = dto.Phone_number;
        entity.Email = dto.Email;
        entity.Location = dto.Location;
        AfterCopyCustomer(dto, entity);
      }
      
      public static CustomerDto AsDto(this Customer entity)
      {
        CustomerDto dto = new CustomerDto();
        CopyCustomer(entity, dto);
        return dto;
      }
      
      public static Customer CopyTo(this CustomerDto source, Customer entity)
      {
        CopyCustomer(source, entity);
        return entity;
      }

      static partial void BeforeCopyNote(Note entity, NoteDto dto);
      static partial void AfterCopyNote(Note entity, NoteDto dto);
      static partial void BeforeCopyNote(NoteDto dto, Note entity);
      static partial void AfterCopyNote(NoteDto dto, Note entity);
      
      private static void CopyNote(Note entity, NoteDto dto)
      {
        BeforeCopyNote(entity, dto);
        CopyLightSpeedModelDtoBase(entity, dto);
        dto.Text = entity.Text;
        dto.CustomerId = entity.CustomerId;
        AfterCopyNote(entity, dto);
      }
      
      private static void CopyNote(NoteDto dto, Note entity)
      {
        BeforeCopyNote(dto, entity);
        CopyLightSpeedModelDtoBase(dto, entity);
        entity.Text = dto.Text;
        entity.CustomerId = dto.CustomerId;
        AfterCopyNote(dto, entity);
      }
      
      public static NoteDto AsDto(this Note entity)
      {
        NoteDto dto = new NoteDto();
        CopyNote(entity, dto);
        return dto;
      }
      
      public static Note CopyTo(this NoteDto source, Note entity)
      {
        CopyNote(source, entity);
        return entity;
      }

      static partial void BeforeCopyGift(Gift entity, GiftDto dto);
      static partial void AfterCopyGift(Gift entity, GiftDto dto);
      static partial void BeforeCopyGift(GiftDto dto, Gift entity);
      static partial void AfterCopyGift(GiftDto dto, Gift entity);
      
      private static void CopyGift(Gift entity, GiftDto dto)
      {
        BeforeCopyGift(entity, dto);
        CopyLightSpeedModelDtoBase(entity, dto);
        dto.title = entity.title;
        dto.description = entity.description;
        dto.comments = entity.comments;
        dto.gift_type = entity.gift_type;
        dto.location = entity.location;
        dto.image = entity.image;
        dto.status = entity.status;
        dto.Latitude = entity.Latitude;
        dto.Longitude = entity.Longitude;
        dto.CustomerId = entity.CustomerId;
        AfterCopyGift(entity, dto);
      }
      
      private static void CopyGift(GiftDto dto, Gift entity)
      {
        BeforeCopyGift(dto, entity);
        CopyLightSpeedModelDtoBase(dto, entity);
        entity.title = dto.title;
        entity.description = dto.description;
        entity.comments = dto.comments;
        entity.gift_type = dto.gift_type;
        entity.location = dto.location;
        entity.image = dto.image;
        entity.status = dto.status;
        entity.Latitude = dto.Latitude;
        entity.Longitude = dto.Longitude;
        entity.CustomerId = dto.CustomerId;
        AfterCopyGift(dto, entity);
      }
      
      public static GiftDto AsDto(this Gift entity)
      {
        GiftDto dto = new GiftDto();
        CopyGift(entity, dto);
        return dto;
      }
      
      public static Gift CopyTo(this GiftDto source, Gift entity)
      {
        CopyGift(source, entity);
        return entity;
      }

      static partial void BeforeCopyTransaction(Transaction entity, TransactionDto dto);
      static partial void AfterCopyTransaction(Transaction entity, TransactionDto dto);
      static partial void BeforeCopyTransaction(TransactionDto dto, Transaction entity);
      static partial void AfterCopyTransaction(TransactionDto dto, Transaction entity);
      
      private static void CopyTransaction(Transaction entity, TransactionDto dto)
      {
        BeforeCopyTransaction(entity, dto);
        CopyLightSpeedModelDtoBase(entity, dto);
        dto.Status = entity.Status;
        dto.CustomerFromId = entity.CustomerFromId;
        dto.CustomerToId = entity.CustomerToId;
        dto.GiftId = entity.GiftId;
        AfterCopyTransaction(entity, dto);
      }
      
      private static void CopyTransaction(TransactionDto dto, Transaction entity)
      {
        BeforeCopyTransaction(dto, entity);
        CopyLightSpeedModelDtoBase(dto, entity);
        entity.Status = dto.Status;
        entity.CustomerFromId = dto.CustomerFromId;
        entity.CustomerToId = dto.CustomerToId;
        entity.GiftId = dto.GiftId;
        AfterCopyTransaction(dto, entity);
      }
      
      public static TransactionDto AsDto(this Transaction entity)
      {
        TransactionDto dto = new TransactionDto();
        CopyTransaction(entity, dto);
        return dto;
      }
      
      public static Transaction CopyTo(this TransactionDto source, Transaction entity)
      {
        CopyTransaction(source, entity);
        return entity;
      }


    }

  }

#endif
}
