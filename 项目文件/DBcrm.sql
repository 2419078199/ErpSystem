GO
create database  [DB_ERP]
go
USE [DB_ERP]
GO
/****** Object:  Table [dbo].[ac_permission]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ac_permission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[url] [nvarchar](50) NULL,
	[pid] [int] NULL,
	[is_menu] [bit] NULL,
	[icon] [nvarchar](50) NULL,
	[remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_Shura_Permissions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ac_role_permission]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ac_role_permission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_id] [int] NOT NULL,
	[permission_id] [int] NOT NULL,
 CONSTRAINT [PK_Shura_R_Role_Permission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ac_userInfo]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ac_userInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account] [nvarchar](20) NULL,
	[pwd] [nvarchar](50) NULL,
	[role_id] [int] NULL,
	[staff_id] [int] NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_User_Permission]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_User_Permission]
AS
SELECT   u.ID AS userid, u.role_id, u.Account, u.Pwd, p.ID, p.Name, p.Url, p.Pid, p.is_menu, p.Icon
FROM      ac_userInfo AS u INNER JOIN
               ac_role_permission AS rp ON u.role_id = rp.role_id INNER JOIN
                ac_permission AS p ON p.ID = rp.permission_id  
--GO
--/****** Object:  View [dbo].[View_Good_Pick]    Script Date: 2020/7/3 18:31:24 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE VIEW [dbo].[View_Good_Pick]
--AS
--SELECT   dbo.Shura_Pickings.GoodID, dbo.Shura_Goods.GoodsName, dbo.Shura_Goods.GoodsNum, dbo.Shura_Pickings.PickingNum, 
--                dbo.Shura_Pickings.PickingTime
--FROM      dbo.Shura_Goods CROSS JOIN
--                dbo.Shura_Pickings

GO
/****** Object:  Table [dbo].[ac_department]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ac_department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_Shura_Department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ac_role]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ac_role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_Shura_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ac_staff]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ac_staff](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[sex] [bit] NOT NULL,
	[no] [nvarchar](10) NOT NULL,
	[tel] [nvarchar](21) NULL,
	[address] [nvarchar](50) NULL,
	[department_id] [int] NULL,
	[status] [bit] NOT NULL,
	[user_id] [int] NULL,
	[remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_StaffInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[au_record]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[au_record](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[source_type] [int] NULL,
	[source_id] [int] NULL,
	[operator_id] [int] NULL,
	[operate_time] [datetime] NULL,
	[operate_desc] [varchar](200) NULL,
	[approver_id] [int] NULL,
	[approve_time] [datetime] NULL,
	[approve_desc] [datetime] NULL,
	[approve_reult] [varchar](200) NULL,
	[remark] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ic_commodity_record]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ic_commodity_record](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[is_in] [bit] NULL,
	[source_category] [int] NULL,
	[source_id] [int] NULL,
	[source_no] [nvarchar](50) NULL,
	[commodity_id] [int] NULL,
	[batch] [varchar](20) NULL,
	[nums] [decimal](18, 2) NULL,
	[reason] [varchar](200) NULL,
	[department_id] [int] NULL,
	[staff_id] [int] NULL,
	[warehouse_id] [int] NULL,
	[operator_id] [int] NULL,
	[operate_time] [datetime] NULL,
	[status] [int] NULL,
	[remark] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ic_commodity_stock]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ic_commodity_stock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[warehouse_id] [int] NULL,
	[commodity_id] [int] NULL,
	[stock] [decimal](18, 2) NULL,
	[remark] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ic_product_record]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ic_product_record](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[is_in] [bit] NULL,
	[source_category] [int] NULL,
	[source_id] [int] NULL,
	[source_no] [nvarchar](50) NULL,
	[product_id] [int] NULL,
	[batch] [varchar](20) NULL,
	[nums] [decimal](18, 2) NULL,
	[reason] [varchar](200) NULL,
	[department_id] [int] NULL,
	[staff_id] [int] NULL,
	[warehouse_id] [int] NULL,
	[operator_id] [int] NULL,
	[operate_time] [datetime] NULL,
	[status] [int] NULL,
	[remark] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ic_product_stock]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ic_product_stock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[warehouse_id] [int] NULL,
	[product_id] [int] NULL,
	[stock] [decimal](18, 2) NULL,
	[remark] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ic_warehouse]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ic_warehouse](
	[id] [int] NOT NULL,
	[no] [nvarchar](50) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[category] [int] NULL,
	[address] [nvarchar](200) NULL,
	[manager_id] [int] NULL,
	[operator_id] [int] NULL,
	[operate_time] [datetime] NULL,
	[status] [int] NULL,
	[remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_IC_WareHouse] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pr_product]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pr_product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category_id] [int] NULL,
	[bar_code] [nvarchar](20) NULL,
	[name] [varchar](50) NULL,
	[price] [money] NULL,
	[stock] [decimal](18, 2) NULL,
	[license_no] [varchar](50) NULL,
	[spec] [varchar](200) NULL,
	[unit] [varchar](50) NULL,
	[place] [varchar](200) NULL,
	[manufacturer] [varchar](200) NOT NULL,
	[operator_id] [int] NULL,
	[operator_time] [datetime] NULL,
	[remark] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pr_product_category]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pr_product_category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[remark] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pr_product_material]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pr_product_material](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[task_id] [int] NULL,
	[commodity_id] [int] NULL,
	[nums] [int] NULL,
	[uses] [varchar](200) NULL,
	[department_id] [int] NULL,
	[staff_id] [int] NULL,
	[receipt_date] [decimal](18, 0) NULL,
	[operator_id] [int] NULL,
	[operate_time] [datetime] NULL,
	[status] [int] NULL,
	[remark] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pr_product_task]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pr_product_task](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[no] [varchar](200) NULL,
	[product_id] [int] NULL,
	[nums] [decimal](18, 2) NULL,
	[product_date] [date] NULL,
	[batch] [varchar](20) NULL,
	[department_id] [int] NULL,
	[operator_id] [int] NULL,
	[operate_time] [datetime] NULL,
	[status] [int] NULL,
	[remark] [varchar](200) NULL,
	[qm_id] [int] NULL,
 CONSTRAINT [PK_PR_Productions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pu_commodity]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pu_commodity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category_id] [int] NULL,
	[supplier_id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[price] [money] NULL,
	[stock] [decimal](18, 2) NULL,
	[place] [nvarchar](200) NULL,
	[spec] [nvarchar](20) NULL,
	[license_no] [nvarchar](50) NULL,
	[operator_id] [int] NULL,
	[operate_time] [datetime] NULL,
	[remark] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pu_commodity_category]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pu_commodity_category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[remark] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pu_order]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pu_order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[no] [nvarchar](50) NULL,
	[commodity_id] [int] NULL,
	[nums] [decimal](18, 2) NULL,
	[purchase_date] [date] NULL,
	[batch] [nchar](10) NULL,
	[amount] [money] NULL,
	[amount_way] [int] NULL,
	[amount_receivable] [money] NULL,
	[amount_received] [money] NULL,
	[handle_id] [int] NULL,
	[operator_id] [int] NULL,
	[operate_time] [datetime] NULL,
	[status] [int] NULL,
	[qm_id] [int] NULL,
	[remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_PU_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pu_supplier]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pu_supplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[postcode] [nvarchar](20) NULL,
	[address] [nvarchar](200) NULL,
	[linkman] [nvarchar](50) NULL,
	[tel] [nvarchar](50) NULL,
	[qq] [nvarchar](20) NULL,
	[weixin] [nvarchar](20) NULL,
	[email] [nvarchar](20) NULL,
	[credit] [nvarchar](50) NULL,
	[remark] [nvarchar](200) NULL,
	[operator_id] [int] NULL,
	[operate_time] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qm_commodity]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[qm_commodity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[no] [varchar](20) NULL,
	[order_id] [int] NULL,
	[qm_date] [date] NULL,
	[result] [int] NULL,
	[handle_id] [int] NULL,
	[operator_id] [int] NULL,
	[operate_time] [datetime] NULL,
	[pic] [varchar](200) NULL,
	[remark] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qm_product]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[qm_product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[no] [varchar](20) NULL,
	[task_id] [int] NULL,
	[qm_date] [date] NULL,
	[result] [int] NULL,
	[handle_id] [int] NULL,
	[operator_id] [int] NULL,
	[operate_time] [datetime] NULL,
	[pic] [varchar](200) NULL,
	[remark] [varchar](200) NULL,
 CONSTRAINT [PK_QM_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sl_customer]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sl_customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[postcode] [nchar](10) NULL,
	[address] [varchar](100) NULL,
	[custtel] [varchar](50) NOT NULL,
	[linkman] [varchar](50) NULL,
	[linktel] [varchar](50) NULL,
	[email] [varchar](32) NULL,
	[sex] [bit] NULL,
	[birthday] [date] NULL,
	[love] [varchar](50) NULL,
	[remark] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sl_order]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sl_order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[no] [nvarchar](20) NOT NULL,
	[customer_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[nums] [decimal](10, 2) NOT NULL,
	[price] [decimal](10, 2) NULL,
	[delivery_date] [date] NULL,
	[delivery_way] [nvarchar](20) NULL,
	[order_date] [date] NULL,
	[order_amount] [decimal](18, 2) NULL,
	[handle_id] [int] NULL,
	[operator_id] [int] NULL,
	[operator_time] [datetime] NULL,
	[status] [int] NULL,
	[remark] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sl_reject]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sl_reject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[no] [nvarchar](50) NULL,
	[order_id] [int] NULL,
	[sale_order_id] [int] NULL,
	[customer_id] [int] NULL,
	[product_id] [int] NULL,
	[reject_date] [date] NULL,
	[nums] [decimal](18, 2) NULL,
	[amount] [decimal](18, 2) NULL,
	[amount_way] [varchar](20) NULL,
	[handle_id] [int] NULL,
	[operator_id] [int] NULL,
	[operator_time] [datetime] NULL,
	[approval_status] [int] NULL,
	[return_status] [int] NULL,
	[remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_SL_Rejects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sl_sale_order]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sl_sale_order](
	[id] [int] NOT NULL,
	[no] [nvarchar](50) NULL,
	[product_id] [int] NULL,
	[customer_id] [int] NULL,
	[order_id] [int] NULL,
	[sale_date] [date] NULL,
	[nums] [decimal](18, 2) NULL,
	[amount] [decimal](18, 2) NULL,
	[amount_way] [varchar](20) NULL,
	[amount_receivable] [decimal](18, 2) NULL,
	[amount_received] [decimal](18, 2) NULL,
	[handle_id] [int] NULL,
	[operator_id] [int] NULL,
	[operator_time] [datetime] NULL,
	[audit_status] [int] NULL,
	[order_status] [int] NULL,
	[Remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_SL_SaleOrders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_config_Item]    Script Date: 2020/7/13 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_config_Item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[keyword] [nvarchar](50) NULL,
	[table_name] [nvarchar](50) NULL,
	[field_name] [nvarchar](50) NULL,
	[option_value] [int] NULL,
	[option_text] [nvarchar](50) NULL,
	[sorting] [int] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_ConfigItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ac_department] ON 

INSERT [dbo].[ac_department] ([id], [name], [remark]) VALUES (1, N'销售部', NULL)
INSERT [dbo].[ac_department] ([id], [name], [remark]) VALUES (2, N'采购部', NULL)
INSERT [dbo].[ac_department] ([id], [name], [remark]) VALUES (3, N'生产部', NULL)
INSERT [dbo].[ac_department] ([id], [name], [remark]) VALUES (4, N'质管部', NULL)
INSERT [dbo].[ac_department] ([id], [name], [remark]) VALUES (5, N'仓管部', NULL)
INSERT [dbo].[ac_department] ([id], [name], [remark]) VALUES (6, N'微机中心', NULL)
SET IDENTITY_INSERT [dbo].[ac_department] OFF
GO
SET IDENTITY_INSERT [dbo].[ac_permission] ON 

INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (8, N'主页', N'', NULL, 1, N'fa-star', NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (9, N'基本信息', N'', NULL, 1, N'fa-folder', NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (10, N'客户信息', N'/Customer/Index', 9, 1, NULL, NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (11, N'供应商信息', N'/Suppliers/Index', 9, 1, NULL, NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (12, N'员工信息', N'/StaffInfo/Index', 9, 1, NULL, NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (13, N'新增', N'/StaffInfo/Add', 12, 0, NULL, NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (14, N'修改', N'/StaffInfo/Edit', 12, 0, NULL, NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (15, N'删除', N'/StaffInfo/Delete', 12, 0, NULL, NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (16, N'原料分类', N'/GoodsCategory/Index', 9, 1, NULL, NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (17, N'销售管理', NULL, NULL, 1, N'fa-shopping-cart', NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (18, N'生产管理', NULL, NULL, 1, N'fa-product-hunt', NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (19, N'仓库管理', NULL, NULL, 1, N'fa-archive', NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (20, N'采购管理', NULL, NULL, 1, N'fa-shopping-basket', NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (21, N'质检管理', NULL, NULL, 1, N'fa-magnet', NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (22, N'系统管理', NULL, NULL, 1, N'fa-cog', NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (23, N'功能管理', N'/Permissions/Index', 22, 1, NULL, NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (24, N'权限管理', N'/Role/Index', 22, 1, NULL, NULL)
INSERT [dbo].[ac_permission] ([id], [name], [url], [pid], [is_menu], [icon], [remark]) VALUES (25, N'产品分类', N'/ProductCategory/Index', 9, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ac_permission] OFF
GO
SET IDENTITY_INSERT [dbo].[ac_role] ON 

INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (1, N'系统管理员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (2, N'客户档案员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (3, N'订单员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (4, N'退货员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (5, N'销售主管', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (6, N'销售部长', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (7, N'供应商档案员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (8, N'采购计划员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (9, N'采购业务员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (10, N'采购主管', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (11, N'采购部长', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (12, N'品质档案员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (13, N'内检员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (14, N'外检员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (15, N'品质主管', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (16, N'品质部长', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (17, N'产品工艺员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (18, N'开发部主管', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (19, N'开发部长', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (20, N'外协员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (21, N'生产计划员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (22, N'生产部长', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (23, N'领料员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (24, N'生产入库员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (25, N'调度员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (26, N'车间主任', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (27, N'原材料创库员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (28, N'半成品创库员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (29, N'成品库管理员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (30, N'辅料库管理员', NULL)
INSERT [dbo].[ac_role] ([id], [name], [remark]) VALUES (31, N'仓库主管', NULL)
SET IDENTITY_INSERT [dbo].[ac_role] OFF
GO
SET IDENTITY_INSERT [dbo].[ac_role_permission] ON 

INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (30, 1, 8)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (31, 1, 9)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (32, 1, 10)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (33, 1, 11)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (34, 1, 12)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (35, 1, 13)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (36, 1, 14)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (37, 1, 15)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (38, 1, 16)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (39, 1, 25)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (40, 1, 17)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (41, 1, 18)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (42, 1, 19)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (43, 1, 20)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (44, 1, 21)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (45, 1, 22)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (46, 1, 23)
INSERT [dbo].[ac_role_permission] ([id], [role_id], [permission_id]) VALUES (47, 1, 24)
SET IDENTITY_INSERT [dbo].[ac_role_permission] OFF
GO
SET IDENTITY_INSERT [dbo].[ac_staff] ON 

INSERT [dbo].[ac_staff] ([id], [name], [sex], [no], [tel], [address], [department_id], [status], [user_id], [remark]) VALUES (1, N'李童辉', 1, N'202001', N'19908484483', N'湖南工程', 1, 1, 1, NULL)
INSERT [dbo].[ac_staff] ([id], [name], [sex], [no], [tel], [address], [department_id], [status], [user_id], [remark]) VALUES (3, N'吴超', 1, N'2002002', N'11111111111', N'qawdasdas', 1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ac_staff] OFF
GO
SET IDENTITY_INSERT [dbo].[ac_userInfo] ON 

INSERT [dbo].[ac_userInfo] ([id], [account], [pwd], [role_id], [staff_id]) VALUES (1, N'admin', N'admin', 1, 1)
SET IDENTITY_INSERT [dbo].[ac_userInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[pr_product_category] ON 

INSERT [dbo].[pr_product_category] ([id], [name], [remark]) VALUES (1, N'ShuraX', NULL)
INSERT [dbo].[pr_product_category] ([id], [name], [remark]) VALUES (2, N'ShuraA', NULL)
SET IDENTITY_INSERT [dbo].[pr_product_category] OFF
GO
SET IDENTITY_INSERT [dbo].[pu_commodity_category] ON 

INSERT [dbo].[pu_commodity_category] ([id], [name], [remark]) VALUES (1, N'CPU', NULL)
INSERT [dbo].[pu_commodity_category] ([id], [name], [remark]) VALUES (2, N'显卡', NULL)
SET IDENTITY_INSERT [dbo].[pu_commodity_category] OFF
GO
SET IDENTITY_INSERT [dbo].[pu_supplier] ON 

INSERT [dbo].[pu_supplier] ([id], [name], [postcode], [address], [linkman], [tel], [qq], [weixin], [email], [credit], [remark], [operator_id], [operate_time]) VALUES (1, N'智星', NULL, N'摡', N'1111111', N'11111111114', NULL, NULL, N'1', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[pu_supplier] OFF
GO
/****** Object:  Index [PK_Shura_EXAMINATIONS]    Script Date: 2020/7/13 19:59:53 ******/
ALTER TABLE [dbo].[au_record] ADD  CONSTRAINT [PK_Shura_EXAMINATIONS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_Shura_GOODSINANDOUTS]    Script Date: 2020/7/13 19:59:53 ******/
ALTER TABLE [dbo].[ic_commodity_record] ADD  CONSTRAINT [PK_Shura_GOODSINANDOUTS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_Shura_GOODSWAREHOUSES]    Script Date: 2020/7/13 19:59:53 ******/
ALTER TABLE [dbo].[ic_commodity_stock] ADD  CONSTRAINT [PK_Shura_GOODSWAREHOUSES] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_Shura_PRODUCTWAREHOUSES]    Script Date: 2020/7/13 19:59:53 ******/
ALTER TABLE [dbo].[ic_product_stock] ADD  CONSTRAINT [PK_Shura_PRODUCTWAREHOUSES] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_Shura_PRODUCTS]    Script Date: 2020/7/13 19:59:53 ******/
ALTER TABLE [dbo].[pr_product] ADD  CONSTRAINT [PK_Shura_PRODUCTS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_Shura_PRODUCTCATEGORYS]    Script Date: 2020/7/13 19:59:53 ******/
ALTER TABLE [dbo].[pr_product_category] ADD  CONSTRAINT [PK_Shura_PRODUCTCATEGORYS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_Shura_MATERIALS]    Script Date: 2020/7/13 19:59:53 ******/
ALTER TABLE [dbo].[pr_product_material] ADD  CONSTRAINT [PK_Shura_MATERIALS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_Shura_GOODS]    Script Date: 2020/7/13 19:59:53 ******/
ALTER TABLE [dbo].[pu_commodity] ADD  CONSTRAINT [PK_Shura_GOODS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_Shura_GOODSTCATEGORYS]    Script Date: 2020/7/13 19:59:53 ******/
ALTER TABLE [dbo].[pu_commodity_category] ADD  CONSTRAINT [PK_Shura_GOODSTCATEGORYS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_Shura_SUPPLIERS]    Script Date: 2020/7/13 19:59:53 ******/
ALTER TABLE [dbo].[pu_supplier] ADD  CONSTRAINT [PK_Shura_SUPPLIERS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_Shura_GOODSQUALITIES]    Script Date: 2020/7/13 19:59:53 ******/
ALTER TABLE [dbo].[qm_commodity] ADD  CONSTRAINT [PK_Shura_GOODSQUALITIES] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_Shura_CUSTOMERS]    Script Date: 2020/7/13 19:59:53 ******/
ALTER TABLE [dbo].[sl_customer] ADD  CONSTRAINT [PK_Shura_CUSTOMERS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_Shura_ORDERS]    Script Date: 2020/7/13 19:59:53 ******/
ALTER TABLE [dbo].[sl_order] ADD  CONSTRAINT [PK_Shura_ORDERS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[pr_product] ADD  CONSTRAINT [DF_Shura_Products_ProductNum]  DEFAULT ((0)) FOR [stock]
GO
ALTER TABLE [dbo].[pu_commodity] ADD  CONSTRAINT [DF_Shura_Goods_GoodsNum]  DEFAULT ((0)) FOR [stock]
GO
ALTER TABLE [dbo].[ac_role_permission]  WITH CHECK ADD  CONSTRAINT [FK_ac_role_permission_ac_permission] FOREIGN KEY([permission_id])
REFERENCES [dbo].[ac_permission] ([id])
GO
ALTER TABLE [dbo].[ac_role_permission] CHECK CONSTRAINT [FK_ac_role_permission_ac_permission]
GO
ALTER TABLE [dbo].[ac_role_permission]  WITH CHECK ADD  CONSTRAINT [FK_ac_role_permission_ac_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[ac_role] ([id])
GO
ALTER TABLE [dbo].[ac_role_permission] CHECK CONSTRAINT [FK_ac_role_permission_ac_role]
GO
ALTER TABLE [dbo].[ac_staff]  WITH CHECK ADD  CONSTRAINT [FK_ac_staff_ac_department] FOREIGN KEY([department_id])
REFERENCES [dbo].[ac_department] ([id])
GO
ALTER TABLE [dbo].[ac_staff] CHECK CONSTRAINT [FK_ac_staff_ac_department]
GO
ALTER TABLE [dbo].[ac_staff]  WITH CHECK ADD  CONSTRAINT [FK_ac_staff_ac_userInfo] FOREIGN KEY([user_id])
REFERENCES [dbo].[ac_userInfo] ([id])
GO
ALTER TABLE [dbo].[ac_staff] CHECK CONSTRAINT [FK_ac_staff_ac_userInfo]
GO
ALTER TABLE [dbo].[ac_userInfo]  WITH CHECK ADD  CONSTRAINT [FK_ac_userInfo_ac_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[ac_role] ([id])
GO
ALTER TABLE [dbo].[ac_userInfo] CHECK CONSTRAINT [FK_ac_userInfo_ac_role]
GO
ALTER TABLE [dbo].[ac_userInfo]  WITH CHECK ADD  CONSTRAINT [FK_ac_userInfo_ac_staff] FOREIGN KEY([staff_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[ac_userInfo] CHECK CONSTRAINT [FK_ac_userInfo_ac_staff]
GO
ALTER TABLE [dbo].[au_record]  WITH CHECK ADD  CONSTRAINT [FK_au_record_ac_staff] FOREIGN KEY([operator_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[au_record] CHECK CONSTRAINT [FK_au_record_ac_staff]
GO
ALTER TABLE [dbo].[au_record]  WITH CHECK ADD  CONSTRAINT [FK_au_record_ac_staff1] FOREIGN KEY([approver_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[au_record] CHECK CONSTRAINT [FK_au_record_ac_staff1]
GO
ALTER TABLE [dbo].[ic_commodity_record]  WITH CHECK ADD  CONSTRAINT [FK_ic_commodity_record_ac_department] FOREIGN KEY([department_id])
REFERENCES [dbo].[ac_department] ([id])
GO
ALTER TABLE [dbo].[ic_commodity_record] CHECK CONSTRAINT [FK_ic_commodity_record_ac_department]
GO
ALTER TABLE [dbo].[ic_commodity_record]  WITH CHECK ADD  CONSTRAINT [FK_ic_commodity_record_ac_staff] FOREIGN KEY([staff_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[ic_commodity_record] CHECK CONSTRAINT [FK_ic_commodity_record_ac_staff]
GO
ALTER TABLE [dbo].[ic_commodity_record]  WITH CHECK ADD  CONSTRAINT [FK_ic_commodity_record_ac_staff1] FOREIGN KEY([operator_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[ic_commodity_record] CHECK CONSTRAINT [FK_ic_commodity_record_ac_staff1]
GO
ALTER TABLE [dbo].[ic_commodity_record]  WITH CHECK ADD  CONSTRAINT [FK_ic_commodity_record_ic_warehouse] FOREIGN KEY([warehouse_id])
REFERENCES [dbo].[ic_warehouse] ([id])
GO
ALTER TABLE [dbo].[ic_commodity_record] CHECK CONSTRAINT [FK_ic_commodity_record_ic_warehouse]
GO
ALTER TABLE [dbo].[ic_commodity_record]  WITH CHECK ADD  CONSTRAINT [FK_ic_commodity_record_pu_commodity] FOREIGN KEY([commodity_id])
REFERENCES [dbo].[pu_commodity] ([id])
GO
ALTER TABLE [dbo].[ic_commodity_record] CHECK CONSTRAINT [FK_ic_commodity_record_pu_commodity]
GO
ALTER TABLE [dbo].[ic_commodity_stock]  WITH CHECK ADD  CONSTRAINT [FK_ic_commodity_stock_ic_warehouse] FOREIGN KEY([warehouse_id])
REFERENCES [dbo].[ic_warehouse] ([id])
GO
ALTER TABLE [dbo].[ic_commodity_stock] CHECK CONSTRAINT [FK_ic_commodity_stock_ic_warehouse]
GO
ALTER TABLE [dbo].[ic_commodity_stock]  WITH CHECK ADD  CONSTRAINT [FK_ic_commodity_stock_pu_commodity] FOREIGN KEY([commodity_id])
REFERENCES [dbo].[pu_commodity] ([id])
GO
ALTER TABLE [dbo].[ic_commodity_stock] CHECK CONSTRAINT [FK_ic_commodity_stock_pu_commodity]
GO
ALTER TABLE [dbo].[ic_product_record]  WITH CHECK ADD  CONSTRAINT [FK_ic_product_record_ac_department] FOREIGN KEY([department_id])
REFERENCES [dbo].[ac_department] ([id])
GO
ALTER TABLE [dbo].[ic_product_record] CHECK CONSTRAINT [FK_ic_product_record_ac_department]
GO
ALTER TABLE [dbo].[ic_product_record]  WITH CHECK ADD  CONSTRAINT [FK_ic_product_record_ac_staff] FOREIGN KEY([staff_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[ic_product_record] CHECK CONSTRAINT [FK_ic_product_record_ac_staff]
GO
ALTER TABLE [dbo].[ic_product_record]  WITH CHECK ADD  CONSTRAINT [FK_ic_product_record_ac_staff1] FOREIGN KEY([operator_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[ic_product_record] CHECK CONSTRAINT [FK_ic_product_record_ac_staff1]
GO
ALTER TABLE [dbo].[ic_product_record]  WITH CHECK ADD  CONSTRAINT [FK_ic_product_record_ic_warehouse] FOREIGN KEY([warehouse_id])
REFERENCES [dbo].[ic_warehouse] ([id])
GO
ALTER TABLE [dbo].[ic_product_record] CHECK CONSTRAINT [FK_ic_product_record_ic_warehouse]
GO
ALTER TABLE [dbo].[ic_product_record]  WITH CHECK ADD  CONSTRAINT [FK_ic_product_record_pr_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[pr_product] ([id])
GO
ALTER TABLE [dbo].[ic_product_record] CHECK CONSTRAINT [FK_ic_product_record_pr_product]
GO
ALTER TABLE [dbo].[ic_product_stock]  WITH CHECK ADD  CONSTRAINT [FK_ic_product_stock_ic_warehouse] FOREIGN KEY([warehouse_id])
REFERENCES [dbo].[ic_warehouse] ([id])
GO
ALTER TABLE [dbo].[ic_product_stock] CHECK CONSTRAINT [FK_ic_product_stock_ic_warehouse]
GO
ALTER TABLE [dbo].[ic_product_stock]  WITH CHECK ADD  CONSTRAINT [FK_ic_product_stock_pr_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[pr_product] ([id])
GO
ALTER TABLE [dbo].[ic_product_stock] CHECK CONSTRAINT [FK_ic_product_stock_pr_product]
GO
ALTER TABLE [dbo].[pr_product]  WITH CHECK ADD  CONSTRAINT [FK_pr_product_pr_product_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[pr_product_category] ([id])
GO
ALTER TABLE [dbo].[pr_product] CHECK CONSTRAINT [FK_pr_product_pr_product_category]
GO
ALTER TABLE [dbo].[pr_product_material]  WITH CHECK ADD  CONSTRAINT [FK_pr_product_material_ac_department] FOREIGN KEY([department_id])
REFERENCES [dbo].[ac_department] ([id])
GO
ALTER TABLE [dbo].[pr_product_material] CHECK CONSTRAINT [FK_pr_product_material_ac_department]
GO
ALTER TABLE [dbo].[pr_product_material]  WITH CHECK ADD  CONSTRAINT [FK_pr_product_material_ac_staff] FOREIGN KEY([staff_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[pr_product_material] CHECK CONSTRAINT [FK_pr_product_material_ac_staff]
GO
ALTER TABLE [dbo].[pr_product_material]  WITH CHECK ADD  CONSTRAINT [FK_pr_product_material_ac_staff1] FOREIGN KEY([operator_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[pr_product_material] CHECK CONSTRAINT [FK_pr_product_material_ac_staff1]
GO
ALTER TABLE [dbo].[pr_product_material]  WITH CHECK ADD  CONSTRAINT [FK_pr_product_material_pr_product_task] FOREIGN KEY([status])
REFERENCES [dbo].[pr_product_task] ([id])
GO
ALTER TABLE [dbo].[pr_product_material] CHECK CONSTRAINT [FK_pr_product_material_pr_product_task]
GO
ALTER TABLE [dbo].[pr_product_material]  WITH CHECK ADD  CONSTRAINT [FK_pr_product_material_pu_commodity] FOREIGN KEY([commodity_id])
REFERENCES [dbo].[pu_commodity] ([id])
GO
ALTER TABLE [dbo].[pr_product_material] CHECK CONSTRAINT [FK_pr_product_material_pu_commodity]
GO
ALTER TABLE [dbo].[pr_product_task]  WITH CHECK ADD  CONSTRAINT [FK_pr_product_task_ac_department] FOREIGN KEY([product_id])
REFERENCES [dbo].[ac_department] ([id])
GO
ALTER TABLE [dbo].[pr_product_task] CHECK CONSTRAINT [FK_pr_product_task_ac_department]
GO
ALTER TABLE [dbo].[pr_product_task]  WITH CHECK ADD  CONSTRAINT [FK_pr_product_task_ac_staff] FOREIGN KEY([operator_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[pr_product_task] CHECK CONSTRAINT [FK_pr_product_task_ac_staff]
GO
ALTER TABLE [dbo].[pr_product_task]  WITH CHECK ADD  CONSTRAINT [FK_pr_product_task_pr_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[pr_product] ([id])
GO
ALTER TABLE [dbo].[pr_product_task] CHECK CONSTRAINT [FK_pr_product_task_pr_product]
GO
ALTER TABLE [dbo].[pr_product_task]  WITH CHECK ADD  CONSTRAINT [FK_pr_product_task_pr_product_task] FOREIGN KEY([id])
REFERENCES [dbo].[pr_product_task] ([id])
GO
ALTER TABLE [dbo].[pr_product_task] CHECK CONSTRAINT [FK_pr_product_task_pr_product_task]
GO
ALTER TABLE [dbo].[pr_product_task]  WITH CHECK ADD  CONSTRAINT [FK_pr_product_task_qm_product] FOREIGN KEY([qm_id])
REFERENCES [dbo].[qm_product] ([id])
GO
ALTER TABLE [dbo].[pr_product_task] CHECK CONSTRAINT [FK_pr_product_task_qm_product]
GO
ALTER TABLE [dbo].[pu_commodity]  WITH CHECK ADD  CONSTRAINT [FK_pu_commodity_ac_staff] FOREIGN KEY([operator_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[pu_commodity] CHECK CONSTRAINT [FK_pu_commodity_ac_staff]
GO
ALTER TABLE [dbo].[pu_commodity]  WITH CHECK ADD  CONSTRAINT [FK_pu_commodity_pu_commodity_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[pu_commodity_category] ([id])
GO
ALTER TABLE [dbo].[pu_commodity] CHECK CONSTRAINT [FK_pu_commodity_pu_commodity_category]
GO
ALTER TABLE [dbo].[pu_commodity]  WITH CHECK ADD  CONSTRAINT [FK_pu_commodity_pu_supplier] FOREIGN KEY([supplier_id])
REFERENCES [dbo].[pu_supplier] ([id])
GO
ALTER TABLE [dbo].[pu_commodity] CHECK CONSTRAINT [FK_pu_commodity_pu_supplier]
GO
ALTER TABLE [dbo].[pu_order]  WITH CHECK ADD  CONSTRAINT [FK_pu_order_ac_staff] FOREIGN KEY([handle_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[pu_order] CHECK CONSTRAINT [FK_pu_order_ac_staff]
GO
ALTER TABLE [dbo].[pu_order]  WITH CHECK ADD  CONSTRAINT [FK_pu_order_pu_commodity] FOREIGN KEY([commodity_id])
REFERENCES [dbo].[pu_commodity] ([id])
GO
ALTER TABLE [dbo].[pu_order] CHECK CONSTRAINT [FK_pu_order_pu_commodity]
GO
ALTER TABLE [dbo].[pu_order]  WITH CHECK ADD  CONSTRAINT [FK_pu_order_qm_commodity] FOREIGN KEY([qm_id])
REFERENCES [dbo].[qm_commodity] ([id])
GO
ALTER TABLE [dbo].[pu_order] CHECK CONSTRAINT [FK_pu_order_qm_commodity]
GO
ALTER TABLE [dbo].[pu_supplier]  WITH CHECK ADD  CONSTRAINT [FK_pu_supplier_ac_staff] FOREIGN KEY([operator_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[pu_supplier] CHECK CONSTRAINT [FK_pu_supplier_ac_staff]
GO
ALTER TABLE [dbo].[qm_commodity]  WITH CHECK ADD  CONSTRAINT [FK_qm_commodity_ac_staff] FOREIGN KEY([handle_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[qm_commodity] CHECK CONSTRAINT [FK_qm_commodity_ac_staff]
GO
ALTER TABLE [dbo].[qm_commodity]  WITH CHECK ADD  CONSTRAINT [FK_qm_commodity_ac_staff1] FOREIGN KEY([operator_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[qm_commodity] CHECK CONSTRAINT [FK_qm_commodity_ac_staff1]
GO
ALTER TABLE [dbo].[qm_commodity]  WITH CHECK ADD  CONSTRAINT [FK_qm_commodity_pu_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[pu_order] ([id])
GO
ALTER TABLE [dbo].[qm_commodity] CHECK CONSTRAINT [FK_qm_commodity_pu_order]
GO
ALTER TABLE [dbo].[qm_commodity]  WITH CHECK ADD  CONSTRAINT [FK_qm_commodity_qm_commodity] FOREIGN KEY([id])
REFERENCES [dbo].[qm_commodity] ([id])
GO
ALTER TABLE [dbo].[qm_commodity] CHECK CONSTRAINT [FK_qm_commodity_qm_commodity]
GO
ALTER TABLE [dbo].[qm_product]  WITH CHECK ADD  CONSTRAINT [FK_qm_product_ac_staff] FOREIGN KEY([handle_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[qm_product] CHECK CONSTRAINT [FK_qm_product_ac_staff]
GO
ALTER TABLE [dbo].[qm_product]  WITH CHECK ADD  CONSTRAINT [FK_qm_product_ac_staff1] FOREIGN KEY([operator_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[qm_product] CHECK CONSTRAINT [FK_qm_product_ac_staff1]
GO
ALTER TABLE [dbo].[qm_product]  WITH CHECK ADD  CONSTRAINT [FK_qm_product_pr_product_task] FOREIGN KEY([task_id])
REFERENCES [dbo].[pr_product_task] ([id])
GO
ALTER TABLE [dbo].[qm_product] CHECK CONSTRAINT [FK_qm_product_pr_product_task]
GO
ALTER TABLE [dbo].[sl_order]  WITH CHECK ADD  CONSTRAINT [FK_sl_order_ac_staff] FOREIGN KEY([handle_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[sl_order] CHECK CONSTRAINT [FK_sl_order_ac_staff]
GO
ALTER TABLE [dbo].[sl_order]  WITH CHECK ADD  CONSTRAINT [FK_sl_order_ac_staff1] FOREIGN KEY([operator_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[sl_order] CHECK CONSTRAINT [FK_sl_order_ac_staff1]
GO
ALTER TABLE [dbo].[sl_order]  WITH CHECK ADD  CONSTRAINT [FK_sl_order_pr_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[pr_product] ([id])
GO
ALTER TABLE [dbo].[sl_order] CHECK CONSTRAINT [FK_sl_order_pr_product]
GO
ALTER TABLE [dbo].[sl_order]  WITH CHECK ADD  CONSTRAINT [FK_sl_order_sl_customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[sl_customer] ([id])
GO
ALTER TABLE [dbo].[sl_order] CHECK CONSTRAINT [FK_sl_order_sl_customer]
GO
ALTER TABLE [dbo].[sl_reject]  WITH CHECK ADD  CONSTRAINT [FK_sl_reject_ac_staff] FOREIGN KEY([handle_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[sl_reject] CHECK CONSTRAINT [FK_sl_reject_ac_staff]
GO
ALTER TABLE [dbo].[sl_reject]  WITH CHECK ADD  CONSTRAINT [FK_sl_reject_ac_staff1] FOREIGN KEY([operator_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[sl_reject] CHECK CONSTRAINT [FK_sl_reject_ac_staff1]
GO
ALTER TABLE [dbo].[sl_reject]  WITH CHECK ADD  CONSTRAINT [FK_sl_reject_pr_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[pr_product] ([id])
GO
ALTER TABLE [dbo].[sl_reject] CHECK CONSTRAINT [FK_sl_reject_pr_product]
GO
ALTER TABLE [dbo].[sl_reject]  WITH CHECK ADD  CONSTRAINT [FK_sl_reject_sl_customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[sl_customer] ([id])
GO
ALTER TABLE [dbo].[sl_reject] CHECK CONSTRAINT [FK_sl_reject_sl_customer]
GO
ALTER TABLE [dbo].[sl_reject]  WITH CHECK ADD  CONSTRAINT [FK_sl_reject_sl_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[sl_order] ([id])
GO
ALTER TABLE [dbo].[sl_reject] CHECK CONSTRAINT [FK_sl_reject_sl_order]
GO
ALTER TABLE [dbo].[sl_reject]  WITH CHECK ADD  CONSTRAINT [FK_sl_reject_sl_sale_order] FOREIGN KEY([sale_order_id])
REFERENCES [dbo].[sl_sale_order] ([id])
GO
ALTER TABLE [dbo].[sl_reject] CHECK CONSTRAINT [FK_sl_reject_sl_sale_order]
GO
ALTER TABLE [dbo].[sl_sale_order]  WITH CHECK ADD  CONSTRAINT [FK_sl_sale_order_ac_staff] FOREIGN KEY([handle_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[sl_sale_order] CHECK CONSTRAINT [FK_sl_sale_order_ac_staff]
GO
ALTER TABLE [dbo].[sl_sale_order]  WITH CHECK ADD  CONSTRAINT [FK_sl_sale_order_ac_staff1] FOREIGN KEY([operator_id])
REFERENCES [dbo].[ac_staff] ([id])
GO
ALTER TABLE [dbo].[sl_sale_order] CHECK CONSTRAINT [FK_sl_sale_order_ac_staff1]
GO
ALTER TABLE [dbo].[sl_sale_order]  WITH CHECK ADD  CONSTRAINT [FK_sl_sale_order_pr_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[pr_product] ([id])
GO
ALTER TABLE [dbo].[sl_sale_order] CHECK CONSTRAINT [FK_sl_sale_order_pr_product]
GO
ALTER TABLE [dbo].[sl_sale_order]  WITH CHECK ADD  CONSTRAINT [FK_sl_sale_order_sl_customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[sl_customer] ([id])
GO
ALTER TABLE [dbo].[sl_sale_order] CHECK CONSTRAINT [FK_sl_sale_order_sl_customer]
GO
ALTER TABLE [dbo].[sl_sale_order]  WITH CHECK ADD  CONSTRAINT [FK_sl_sale_order_sl_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[sl_order] ([id])
GO
ALTER TABLE [dbo].[sl_sale_order] CHECK CONSTRAINT [FK_sl_sale_order_sl_order]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_department', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_department', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_department', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_permission', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_permission', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_permission', @level2type=N'COLUMN',@level2name=N'url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_permission', @level2type=N'COLUMN',@level2name=N'pid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否菜单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_permission', @level2type=N'COLUMN',@level2name=N'is_menu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_permission', @level2type=N'COLUMN',@level2name=N'icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_permission', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_role', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_role', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_role', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_role_permission', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_role_permission', @level2type=N'COLUMN',@level2name=N'role_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_role_permission', @level2type=N'COLUMN',@level2name=N'permission_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_staff', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_staff', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0：男，1：女' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_staff', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_staff', @level2type=N'COLUMN',@level2name=N'no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_staff', @level2type=N'COLUMN',@level2name=N'tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_staff', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_staff', @level2type=N'COLUMN',@level2name=N'department_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0：离职，1：在职' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_staff', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_staff', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_staff', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_userInfo', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_userInfo', @level2type=N'COLUMN',@level2name=N'account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_userInfo', @level2type=N'COLUMN',@level2name=N'pwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_userInfo', @level2type=N'COLUMN',@level2name=N'role_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ac_userInfo', @level2type=N'COLUMN',@level2name=N'staff_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'au_record', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审批类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'au_record', @level2type=N'COLUMN',@level2name=N'source_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审批单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'au_record', @level2type=N'COLUMN',@level2name=N'source_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'au_record', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'au_record', @level2type=N'COLUMN',@level2name=N'operate_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作意见' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'au_record', @level2type=N'COLUMN',@level2name=N'operate_desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'au_record', @level2type=N'COLUMN',@level2name=N'approver_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'au_record', @level2type=N'COLUMN',@level2name=N'approve_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'au_record', @level2type=N'COLUMN',@level2name=N'approve_desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理结论' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'au_record', @level2type=N'COLUMN',@level2name=N'approve_reult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'au_record', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出入库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'is_in'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'源单类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'source_category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'源单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'source_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'源单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'source_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'commodity_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'batch'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'nums'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原因' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'reason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出入库部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'department_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出入库员工' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'staff_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'warehouse_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'operate_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_record', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_stock', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_stock', @level2type=N'COLUMN',@level2name=N'warehouse_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_stock', @level2type=N'COLUMN',@level2name=N'commodity_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_stock', @level2type=N'COLUMN',@level2name=N'stock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_commodity_stock', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出入库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'is_in'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'源单类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'source_category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'源单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'source_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原单订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'source_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'batch'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'nums'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原因' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'reason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'department_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'staff_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'warehouse_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'operate_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_record', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_stock', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_stock', @level2type=N'COLUMN',@level2name=N'warehouse_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_stock', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_stock', @level2type=N'COLUMN',@level2name=N'stock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_product_stock', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_warehouse', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_warehouse', @level2type=N'COLUMN',@level2name=N'no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_warehouse', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_warehouse', @level2type=N'COLUMN',@level2name=N'category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_warehouse', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_warehouse', @level2type=N'COLUMN',@level2name=N'manager_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_warehouse', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_warehouse', @level2type=N'COLUMN',@level2name=N'operate_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_warehouse', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ic_warehouse', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'category_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'bar_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'stock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批文' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'license_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'spec'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'unit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产地' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'place'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产厂家' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'manufacturer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'operator_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_category', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_category', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_category', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_material', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产任务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_material', @level2type=N'COLUMN',@level2name=N'task_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_material', @level2type=N'COLUMN',@level2name=N'commodity_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_material', @level2type=N'COLUMN',@level2name=N'nums'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用途' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_material', @level2type=N'COLUMN',@level2name=N'uses'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领用部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_material', @level2type=N'COLUMN',@level2name=N'department_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领用人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_material', @level2type=N'COLUMN',@level2name=N'staff_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领用日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_material', @level2type=N'COLUMN',@level2name=N'receipt_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_material', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_material', @level2type=N'COLUMN',@level2name=N'operate_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_material', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_material', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_task', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_task', @level2type=N'COLUMN',@level2name=N'no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_task', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_task', @level2type=N'COLUMN',@level2name=N'nums'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_task', @level2type=N'COLUMN',@level2name=N'product_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_task', @level2type=N'COLUMN',@level2name=N'batch'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_task', @level2type=N'COLUMN',@level2name=N'department_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_task', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_task', @level2type=N'COLUMN',@level2name=N'operate_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_task', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_task', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'质检编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pr_product_task', @level2type=N'COLUMN',@level2name=N'qm_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity', @level2type=N'COLUMN',@level2name=N'category_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity', @level2type=N'COLUMN',@level2name=N'supplier_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity', @level2type=N'COLUMN',@level2name=N'stock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产地' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity', @level2type=N'COLUMN',@level2name=N'place'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity', @level2type=N'COLUMN',@level2name=N'spec'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产批文' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity', @level2type=N'COLUMN',@level2name=N'license_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity', @level2type=N'COLUMN',@level2name=N'operate_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity_category', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity_category', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_commodity_category', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'commodity_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'nums'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'purchase_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'batch'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'amount_way'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应收金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'amount_receivable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实收金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'amount_received'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经手人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'handle_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'operate_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'质检单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'qm_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_order', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_supplier', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_supplier', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮编' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_supplier', @level2type=N'COLUMN',@level2name=N'postcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_supplier', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_supplier', @level2type=N'COLUMN',@level2name=N'linkman'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_supplier', @level2type=N'COLUMN',@level2name=N'tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_supplier', @level2type=N'COLUMN',@level2name=N'qq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_supplier', @level2type=N'COLUMN',@level2name=N'weixin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_supplier', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'信誉度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_supplier', @level2type=N'COLUMN',@level2name=N'credit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pu_supplier', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_commodity', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'质检单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_commodity', @level2type=N'COLUMN',@level2name=N'no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_commodity', @level2type=N'COLUMN',@level2name=N'order_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'质检日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_commodity', @level2type=N'COLUMN',@level2name=N'qm_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结论' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_commodity', @level2type=N'COLUMN',@level2name=N'result'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经手人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_commodity', @level2type=N'COLUMN',@level2name=N'handle_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_commodity', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_commodity', @level2type=N'COLUMN',@level2name=N'operate_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_commodity', @level2type=N'COLUMN',@level2name=N'pic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_commodity', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_product', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'质检单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_product', @level2type=N'COLUMN',@level2name=N'no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_product', @level2type=N'COLUMN',@level2name=N'task_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'质检日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_product', @level2type=N'COLUMN',@level2name=N'qm_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'质检结论' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_product', @level2type=N'COLUMN',@level2name=N'result'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经手人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_product', @level2type=N'COLUMN',@level2name=N'handle_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_product', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_product', @level2type=N'COLUMN',@level2name=N'operate_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'质检图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_product', @level2type=N'COLUMN',@level2name=N'pic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_product', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_customer', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_customer', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮编' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_customer', @level2type=N'COLUMN',@level2name=N'postcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_customer', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_customer', @level2type=N'COLUMN',@level2name=N'custtel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_customer', @level2type=N'COLUMN',@level2name=N'linkman'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_customer', @level2type=N'COLUMN',@level2name=N'linktel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_customer', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_customer', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_customer', @level2type=N'COLUMN',@level2name=N'birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'爱好' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_customer', @level2type=N'COLUMN',@level2name=N'love'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_customer', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'customer_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'nums'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交货日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'delivery_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交货方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'delivery_way'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下单时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'order_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'order_amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经手人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'handle_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'operator_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态(0待审核，1已审核，2待发货，3已出库，-1审核不通过)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_order', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退货单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'order_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'sale_order_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'customer_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退单日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'reject_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'nums'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'amount_way'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经手人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'handle_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'operator_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审批状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'approval_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退单状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'return_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_reject', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'customer_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'order_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'sale_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'nums'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'amount_way'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应收金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'amount_receivable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实收金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'amount_received'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经手人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'handle_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'operator_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'operator_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审批状态  0待审批  1已审批  -1审批不通过' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'audit_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0待提货  1 已出库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'order_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sl_sale_order', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config_Item', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config_Item', @level2type=N'COLUMN',@level2name=N'keyword'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config_Item', @level2type=N'COLUMN',@level2name=N'table_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config_Item', @level2type=N'COLUMN',@level2name=N'field_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config_Item', @level2type=N'COLUMN',@level2name=N'option_value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config_Item', @level2type=N'COLUMN',@level2name=N'option_text'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config_Item', @level2type=N'COLUMN',@level2name=N'sorting'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config_Item', @level2type=N'COLUMN',@level2name=N'status'
GO
