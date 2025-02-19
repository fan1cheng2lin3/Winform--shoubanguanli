﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace 手办管理系统
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="shoubanguanli")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void Insertshangpinbiao(shangpinbiao instance);
    partial void Updateshangpinbiao(shangpinbiao instance);
    partial void Deleteshangpinbiao(shangpinbiao instance);
    partial void InsertCartItem(CartItem instance);
    partial void UpdateCartItem(CartItem instance);
    partial void DeleteCartItem(CartItem instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::手办管理系统.Properties.Settings.Default.shoubanguanliConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<shangpinbiao> shangpinbiao
		{
			get
			{
				return this.GetTable<shangpinbiao>();
			}
		}
		
		public System.Data.Linq.Table<CartItem> CartItem
		{
			get
			{
				return this.GetTable<CartItem>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.shangpinbiao")]
	public partial class shangpinbiao : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Goods_ID;
		
		private string _Goods_Name;
		
		private string _Classification_ID;
		
		private string _Supplier_ID;
		
		private decimal _Unit_Price;
		
		private System.Nullable<int> _Stock_Quantity;
		
		private string _Order_Quantity;
		
		private System.Nullable<decimal> _chengben;
		
		private string _image;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnGoods_IDChanging(int value);
    partial void OnGoods_IDChanged();
    partial void OnGoods_NameChanging(string value);
    partial void OnGoods_NameChanged();
    partial void OnClassification_IDChanging(string value);
    partial void OnClassification_IDChanged();
    partial void OnSupplier_IDChanging(string value);
    partial void OnSupplier_IDChanged();
    partial void OnUnit_PriceChanging(decimal value);
    partial void OnUnit_PriceChanged();
    partial void OnStock_QuantityChanging(System.Nullable<int> value);
    partial void OnStock_QuantityChanged();
    partial void OnOrder_QuantityChanging(string value);
    partial void OnOrder_QuantityChanged();
    partial void OnchengbenChanging(System.Nullable<decimal> value);
    partial void OnchengbenChanged();
    partial void OnimageChanging(string value);
    partial void OnimageChanged();
    #endregion
		
		public shangpinbiao()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Goods_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Goods_ID
		{
			get
			{
				return this._Goods_ID;
			}
			set
			{
				if ((this._Goods_ID != value))
				{
					this.OnGoods_IDChanging(value);
					this.SendPropertyChanging();
					this._Goods_ID = value;
					this.SendPropertyChanged("Goods_ID");
					this.OnGoods_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Goods_Name", DbType="NVarChar(50)")]
		public string Goods_Name
		{
			get
			{
				return this._Goods_Name;
			}
			set
			{
				if ((this._Goods_Name != value))
				{
					this.OnGoods_NameChanging(value);
					this.SendPropertyChanging();
					this._Goods_Name = value;
					this.SendPropertyChanged("Goods_Name");
					this.OnGoods_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Classification_ID", DbType="NVarChar(50)")]
		public string Classification_ID
		{
			get
			{
				return this._Classification_ID;
			}
			set
			{
				if ((this._Classification_ID != value))
				{
					this.OnClassification_IDChanging(value);
					this.SendPropertyChanging();
					this._Classification_ID = value;
					this.SendPropertyChanged("Classification_ID");
					this.OnClassification_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Supplier_ID", DbType="NVarChar(50)")]
		public string Supplier_ID
		{
			get
			{
				return this._Supplier_ID;
			}
			set
			{
				if ((this._Supplier_ID != value))
				{
					this.OnSupplier_IDChanging(value);
					this.SendPropertyChanging();
					this._Supplier_ID = value;
					this.SendPropertyChanged("Supplier_ID");
					this.OnSupplier_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Unit_Price", DbType="Money NOT NULL")]
		public decimal Unit_Price
		{
			get
			{
				return this._Unit_Price;
			}
			set
			{
				if ((this._Unit_Price != value))
				{
					this.OnUnit_PriceChanging(value);
					this.SendPropertyChanging();
					this._Unit_Price = value;
					this.SendPropertyChanged("Unit_Price");
					this.OnUnit_PriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Stock_Quantity", DbType="Int")]
		public System.Nullable<int> Stock_Quantity
		{
			get
			{
				return this._Stock_Quantity;
			}
			set
			{
				if ((this._Stock_Quantity != value))
				{
					this.OnStock_QuantityChanging(value);
					this.SendPropertyChanging();
					this._Stock_Quantity = value;
					this.SendPropertyChanged("Stock_Quantity");
					this.OnStock_QuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Order_Quantity", DbType="NVarChar(50)")]
		public string Order_Quantity
		{
			get
			{
				return this._Order_Quantity;
			}
			set
			{
				if ((this._Order_Quantity != value))
				{
					this.OnOrder_QuantityChanging(value);
					this.SendPropertyChanging();
					this._Order_Quantity = value;
					this.SendPropertyChanged("Order_Quantity");
					this.OnOrder_QuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_chengben", DbType="Money")]
		public System.Nullable<decimal> chengben
		{
			get
			{
				return this._chengben;
			}
			set
			{
				if ((this._chengben != value))
				{
					this.OnchengbenChanging(value);
					this.SendPropertyChanging();
					this._chengben = value;
					this.SendPropertyChanged("chengben");
					this.OnchengbenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_image", DbType="NVarChar(200)")]
		public string image
		{
			get
			{
				return this._image;
			}
			set
			{
				if ((this._image != value))
				{
					this.OnimageChanging(value);
					this.SendPropertyChanging();
					this._image = value;
					this.SendPropertyChanged("image");
					this.OnimageChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CartItem")]
	public partial class CartItem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Product_ID;
		
		private int _Customer_ID;
		
		private System.Nullable<int> _Proid;
		
		private string _ProName;
		
		private System.Nullable<decimal> _ListPrice;
		
		private System.Nullable<decimal> _UnPrice;
		
		private System.Nullable<int> _Qty;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProduct_IDChanging(int value);
    partial void OnProduct_IDChanged();
    partial void OnCustomer_IDChanging(int value);
    partial void OnCustomer_IDChanged();
    partial void OnProidChanging(System.Nullable<int> value);
    partial void OnProidChanged();
    partial void OnProNameChanging(string value);
    partial void OnProNameChanged();
    partial void OnListPriceChanging(System.Nullable<decimal> value);
    partial void OnListPriceChanged();
    partial void OnUnPriceChanging(System.Nullable<decimal> value);
    partial void OnUnPriceChanged();
    partial void OnQtyChanging(System.Nullable<int> value);
    partial void OnQtyChanged();
    #endregion
		
		public CartItem()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Product_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Product_ID
		{
			get
			{
				return this._Product_ID;
			}
			set
			{
				if ((this._Product_ID != value))
				{
					this.OnProduct_IDChanging(value);
					this.SendPropertyChanging();
					this._Product_ID = value;
					this.SendPropertyChanged("Product_ID");
					this.OnProduct_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Customer_ID", DbType="Int NOT NULL")]
		public int Customer_ID
		{
			get
			{
				return this._Customer_ID;
			}
			set
			{
				if ((this._Customer_ID != value))
				{
					this.OnCustomer_IDChanging(value);
					this.SendPropertyChanging();
					this._Customer_ID = value;
					this.SendPropertyChanged("Customer_ID");
					this.OnCustomer_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Proid", DbType="Int")]
		public System.Nullable<int> Proid
		{
			get
			{
				return this._Proid;
			}
			set
			{
				if ((this._Proid != value))
				{
					this.OnProidChanging(value);
					this.SendPropertyChanging();
					this._Proid = value;
					this.SendPropertyChanged("Proid");
					this.OnProidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProName", DbType="NVarChar(50)")]
		public string ProName
		{
			get
			{
				return this._ProName;
			}
			set
			{
				if ((this._ProName != value))
				{
					this.OnProNameChanging(value);
					this.SendPropertyChanging();
					this._ProName = value;
					this.SendPropertyChanged("ProName");
					this.OnProNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ListPrice", DbType="Decimal(10,2)")]
		public System.Nullable<decimal> ListPrice
		{
			get
			{
				return this._ListPrice;
			}
			set
			{
				if ((this._ListPrice != value))
				{
					this.OnListPriceChanging(value);
					this.SendPropertyChanging();
					this._ListPrice = value;
					this.SendPropertyChanged("ListPrice");
					this.OnListPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UnPrice", DbType="Decimal(10,2)")]
		public System.Nullable<decimal> UnPrice
		{
			get
			{
				return this._UnPrice;
			}
			set
			{
				if ((this._UnPrice != value))
				{
					this.OnUnPriceChanging(value);
					this.SendPropertyChanging();
					this._UnPrice = value;
					this.SendPropertyChanged("UnPrice");
					this.OnUnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Qty", DbType="Int")]
		public System.Nullable<int> Qty
		{
			get
			{
				return this._Qty;
			}
			set
			{
				if ((this._Qty != value))
				{
					this.OnQtyChanging(value);
					this.SendPropertyChanging();
					this._Qty = value;
					this.SendPropertyChanged("Qty");
					this.OnQtyChanged();
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
