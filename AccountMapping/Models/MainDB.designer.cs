﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccountMapping.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Main")]
	public partial class MainDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 擴充性方法定義
    partial void OnCreated();
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    #endregion
		
		public MainDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MainDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MainDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MainDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MainDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<User> User
		{
			get
			{
				return this.GetTable<User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _UserName;
		
		private string _LineUserID;
		
		private string _LineNotifyToken;
		
		private string _LineLoginUserID;
		
		private string _Memo;
		
		private string _Pwd;
		
    #region 擴充性方法定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnLineUserIDChanging(string value);
    partial void OnLineUserIDChanged();
    partial void OnLineNotifyTokenChanging(string value);
    partial void OnLineNotifyTokenChanged();
    partial void OnLineLoginUserIDChanging(string value);
    partial void OnLineLoginUserIDChanged();
    partial void OnMemoChanging(string value);
    partial void OnMemoChanged();
    partial void OnPwdChanging(string value);
    partial void OnPwdChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LineUserID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string LineUserID
		{
			get
			{
				return this._LineUserID;
			}
			set
			{
				if ((this._LineUserID != value))
				{
					this.OnLineUserIDChanging(value);
					this.SendPropertyChanging();
					this._LineUserID = value;
					this.SendPropertyChanged("LineUserID");
					this.OnLineUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LineNotifyToken", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string LineNotifyToken
		{
			get
			{
				return this._LineNotifyToken;
			}
			set
			{
				if ((this._LineNotifyToken != value))
				{
					this.OnLineNotifyTokenChanging(value);
					this.SendPropertyChanging();
					this._LineNotifyToken = value;
					this.SendPropertyChanged("LineNotifyToken");
					this.OnLineNotifyTokenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LineLoginUserID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string LineLoginUserID
		{
			get
			{
				return this._LineLoginUserID;
			}
			set
			{
				if ((this._LineLoginUserID != value))
				{
					this.OnLineLoginUserIDChanging(value);
					this.SendPropertyChanging();
					this._LineLoginUserID = value;
					this.SendPropertyChanged("LineLoginUserID");
					this.OnLineLoginUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Memo", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Memo
		{
			get
			{
				return this._Memo;
			}
			set
			{
				if ((this._Memo != value))
				{
					this.OnMemoChanging(value);
					this.SendPropertyChanging();
					this._Memo = value;
					this.SendPropertyChanged("Memo");
					this.OnMemoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pwd", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Pwd
		{
			get
			{
				return this._Pwd;
			}
			set
			{
				if ((this._Pwd != value))
				{
					this.OnPwdChanging(value);
					this.SendPropertyChanging();
					this._Pwd = value;
					this.SendPropertyChanged("Pwd");
					this.OnPwdChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591