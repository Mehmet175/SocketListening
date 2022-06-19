﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArduinoTcp
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ArduinoProject")]
	public partial class DbContextDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDataLog(DataLog instance);
    partial void UpdateDataLog(DataLog instance);
    partial void DeleteDataLog(DataLog instance);
    #endregion
		
		public DbContextDataContext() : 
				base(global::ArduinoTcp.Properties.Settings.Default.ArduinoProjectConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DbContextDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbContextDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbContextDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbContextDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<DataLog> DataLogs
		{
			get
			{
				return this.GetTable<DataLog>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DataLog")]
	public partial class DataLog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Value1;
		
		private string _Value2;
		
		private string _Value3;
		
		private string _Value4;
		
		private string _Value5;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnValue1Changing(string value);
    partial void OnValue1Changed();
    partial void OnValue2Changing(string value);
    partial void OnValue2Changed();
    partial void OnValue3Changing(string value);
    partial void OnValue3Changed();
    partial void OnValue4Changing(string value);
    partial void OnValue4Changed();
    partial void OnValue5Changing(string value);
    partial void OnValue5Changed();
    #endregion
		
		public DataLog()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value1", DbType="NVarChar(50)")]
		public string Value1
		{
			get
			{
				return this._Value1;
			}
			set
			{
				if ((this._Value1 != value))
				{
					this.OnValue1Changing(value);
					this.SendPropertyChanging();
					this._Value1 = value;
					this.SendPropertyChanged("Value1");
					this.OnValue1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value2", DbType="NVarChar(50)")]
		public string Value2
		{
			get
			{
				return this._Value2;
			}
			set
			{
				if ((this._Value2 != value))
				{
					this.OnValue2Changing(value);
					this.SendPropertyChanging();
					this._Value2 = value;
					this.SendPropertyChanged("Value2");
					this.OnValue2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value3", DbType="NVarChar(50)")]
		public string Value3
		{
			get
			{
				return this._Value3;
			}
			set
			{
				if ((this._Value3 != value))
				{
					this.OnValue3Changing(value);
					this.SendPropertyChanging();
					this._Value3 = value;
					this.SendPropertyChanged("Value3");
					this.OnValue3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value4", DbType="NVarChar(50)")]
		public string Value4
		{
			get
			{
				return this._Value4;
			}
			set
			{
				if ((this._Value4 != value))
				{
					this.OnValue4Changing(value);
					this.SendPropertyChanging();
					this._Value4 = value;
					this.SendPropertyChanged("Value4");
					this.OnValue4Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value5", DbType="NVarChar(50)")]
		public string Value5
		{
			get
			{
				return this._Value5;
			}
			set
			{
				if ((this._Value5 != value))
				{
					this.OnValue5Changing(value);
					this.SendPropertyChanging();
					this._Value5 = value;
					this.SendPropertyChanged("Value5");
					this.OnValue5Changed();
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