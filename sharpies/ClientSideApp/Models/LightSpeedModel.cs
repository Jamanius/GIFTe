using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;
using Mindscape.LightSpeed.Linq;

namespace ClientSideApp.Models
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table("Customers", IdentityMethod=IdentityMethod.KeyTable)]
  [System.Runtime.Serialization.DataContract]
  public partial class Customer : Entity<int>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _name;
    [ValidateLength(0, 50)]
    private string _phone_number;
    [ValidateLength(0, 300)]
    private string _email;

    #pragma warning disable 649  // "Field is never assigned to" - LightSpeed assigns these fields internally
    private readonly System.DateTime _createdOn;
    private readonly System.DateTime _updatedOn;
    private readonly System.Nullable<System.DateTime> _deletedOn;
    #pragma warning restore 649    

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Name entity attribute.</summary>
    public const string NameField = "Name";
    /// <summary>Identifies the Phone_number entity attribute.</summary>
    public const string Phone_numberField = "Phone_number";
    /// <summary>Identifies the Email entity attribute.</summary>
    public const string EmailField = "Email";
    /// <summary>Identifies the CreatedOn entity attribute.</summary>
    public const string CreatedOnField = "CreatedOn";
    /// <summary>Identifies the UpdatedOn entity attribute.</summary>
    public const string UpdatedOnField = "UpdatedOn";
    /// <summary>Identifies the DeletedOn entity attribute.</summary>
    public const string DeletedOnField = "DeletedOn";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Customer")]
    private readonly EntityCollection<Note> _notes = new EntityCollection<Note>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<Note> Notes
    {
      get { return Get(_notes); }
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
  [Table("Notes", IdentityMethod=IdentityMethod.KeyTable)]
  public partial class Note : Entity<int>
  {
    #region Fields
  
    [ValidatePresence]
    private string _text;
    private int _customerId;

    #pragma warning disable 649  // "Field is never assigned to" - LightSpeed assigns these fields internally
    private readonly System.DateTime _createdOn;
    private readonly System.DateTime _updatedOn;
    private readonly System.Nullable<System.DateTime> _deletedOn;
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


    [System.Diagnostics.DebuggerNonUserCode]
    public string Text
    {
      get { return Get(ref _text, "Text"); }
      set { Set(ref _text, value, "Text"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Customer" /> property.</summary>
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
  public partial class Gift : Entity<int>
  {
    #region Fields
  
    private string _title;
    private string _description;
    private string _comments;
    private string _gift_type;
    private string _location;

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


    #endregion
    
    #region Properties



    [System.Diagnostics.DebuggerNonUserCode]
    public string title
    {
      get { return Get(ref _title, "title"); }
      set { Set(ref _title, value, "title"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string description
    {
      get { return Get(ref _description, "description"); }
      set { Set(ref _description, value, "description"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string comments
    {
      get { return Get(ref _comments, "comments"); }
      set { Set(ref _comments, value, "comments"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string gift_type
    {
      get { return Get(ref _gift_type, "gift_type"); }
      set { Set(ref _gift_type, value, "gift_type"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string location
    {
      get { return Get(ref _location, "location"); }
      set { Set(ref _location, value, "location"); }
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
    
  }

}
