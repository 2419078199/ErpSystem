CREATE TABLE [dbo].[ac_permission](    --菜单权限表
	[id] [int] IDENTITY(1,1) NOT NULL,--编号
	[name] [nvarchar](50) NOT NULL,   --名称
	[url] [nvarchar](50) NULL,        --URL
	[pid] [int] NULL,                 --上级权限
	[is_menu] [bit] NULL,             --是否菜单
	[icon] [nvarchar](50) NULL,       --菜单图标
	[remark] [nvarchar](200) NULL,    --备注
)
CREATE TABLE [dbo].[ac_role_permission](--角色权限表
	[id] [int] IDENTITY(1,1) NOT NULL,--编号
	[role_id] [int] NOT NULL,         --角色编号
	[permission_id] [int] NOT NULL,   --权限编号
)
CREATE TABLE [dbo].[ac_userInfo](     --用户信息表
	[id] [int] IDENTITY(1,1) NOT NULL,--编号
	[account] [nvarchar](20) NULL,    --账号
	[pwd] [nvarchar](50) NULL,        --密码
	[role_id] [int] NULL,             --角色编号
	[staff_id] [int] NULL,            --员工编号
)
CREATE TABLE [dbo].[ac_department](   --部门表
	[id] [int] IDENTITY(1,1) NOT NULL,--编号
	[name] [nvarchar](50) NOT NULL,--名称
	[remark] [nvarchar](200) NULL,--备注
) 
CREATE TABLE [dbo].[ac_role](           --角色表
	[id] [int] IDENTITY(1,1) NOT NULL,  --编号 
	[name] [nvarchar](50) NOT NULL,     --名称
	[remark] [nvarchar](200) NULL,      --备注
) 
CREATE TABLE [dbo].[ac_staff](        --员工表
	[id] [int] IDENTITY(1,1) NOT NULL,--编号
	[name] [nvarchar](20) NOT NULL,   --姓名
	[sex] [bit] NOT NULL,             --性别0：男，1：女
	[no] [nvarchar](10) NOT NULL,     --员工编号
	[tel] [nvarchar](21) NULL,        --电话
	[address] [nvarchar](50) NULL,    -- 地址
	[department_id] [int] NULL,       --部门
	[status] [bit] NOT NULL,          --0：离职，1：在职
	[user_id] [int] NULL,             --账户id
	[remark] [nvarchar](200) NULL,    --备注
)
CREATE TABLE [dbo].[au_record](       --审批记录表
	[id] [int] IDENTITY(1,1) NOT NULL,--编号
	[source_type] [int] NULL,         --审批类型
	[source_id] [int] NULL,           --审批单号
	[operator_id] [int] NULL,         --操作人
	[operate_time] [datetime] NULL,   --处理时间
	[operate_desc] [varchar](200) NULL,--操作意见
	[approver_id] [int] NULL,          --处理人
	[approve_time] [datetime] NULL,    --处理时间
	[approve_desc] [datetime] NULL,    --处理备注
	[approve_reult] [varchar](200) NULL,--处理结论
	[remark] [varchar](200) NULL        --备注
) 
CREATE TABLE [dbo].[ic_commodity_record](--商品记录表
	[id] [int] IDENTITY(1,1) NOT NULL, --编号
	[name] [nvarchar](50) NULL,        --主题
	[is_in] [bit] NULL,                --是否出入库
	[source_category] [int] NULL,      --源单类型
	[source_id] [int] NULL,            --源单ID
	[source_no] [nvarchar](50) NULL,   --源单编号
	[commodity_id] [int] NULL,         --商品（ID）
	[batch] [varchar](20) NULL,        --批次号
	[nums] [decimal](18, 2) NULL,      --数量
	[reason] [varchar](200) NULL,      --原因
	[department_id] [int] NULL,        --出入库部门
	[staff_id] [int] NULL,             --出入库员工
	[warehouse_id] [int] NULL,         --仓库
	[operator_id] [int] NULL,          --操作人
	[operate_time] [datetime] NULL,    --操作时间
	[status] [int] NULL,               --状态
	[remark] [varchar](200) NULL       --备注
)
CREATE TABLE [dbo].[ic_commodity_stock](--商品库存表
	[id] [int] IDENTITY(1,1) NOT NULL, --编号
	[warehouse_id] [int] NULL,         --仓库
	[commodity_id] [int] NULL,         --商品编号
	[stock] [decimal](18, 2) NULL,     --库存
	[remark] [nvarchar](200) NULL      --备注
) 
CREATE TABLE [dbo].[ic_product_record](--产品记录表
	[id] [int] IDENTITY(1,1) NOT NULL, --编号
	[name] [nvarchar](50) NULL,        --名称
	[is_in] [bit] NULL,                --是否出入库
	[source_category] [int] NULL,      --源单类型
	[source_id] [int] NULL,            --源单编号
	[source_no] [nvarchar](50) NULL,   --原单订单号
	[product_id] [int] NULL,           --产品编号
	[batch] [varchar](20) NULL,        --批次号
	[nums] [decimal](18, 2) NULL,      --数量
	[reason] [varchar](200) NULL,      --原因
	[department_id] [int] NULL,        --部门编号
	[staff_id] [int] NULL,             --员工编号
	[warehouse_id] [int] NULL,         --仓库编号
	[operator_id] [int] NULL,          --操作人
	[operate_time] [datetime] NULL,    --操作时间
	[status] [int] NULL,               --状态
	[remark] [varchar](200) NULL       --备注
) 
CREATE TABLE [dbo].[ic_product_stock](  --产品库存表
	[id] [int] IDENTITY(1,1) NOT NULL, --编号
	[warehouse_id] [int] NULL,         --仓库号
	[product_id] [int] NULL,           --产品编号
	[stock] [decimal](18, 2) NULL,     --库存数
	[remark] [nvarchar](200) NULL      --备注
) 
CREATE TABLE [dbo].[ic_warehouse](   --仓库表
	[id] [int] NOT NULL,             --编号
	[no] [nvarchar](50) NOT NULL,    --仓库编号
	[name] [nvarchar](100) NOT NULL, --名称
	[category] [int] NULL,           --仓库类型
	[address] [nvarchar](200) NULL,  --地址
	[manager_id] [int] NULL,         --管理员
	[operator_id] [int] NULL,        --操作人
	[operate_time] [datetime] NULL,  --操作时间
	[status] [int] NULL,             --状态
	[remark] [nvarchar](200) NULL,   --备注
) 
CREATE TABLE [dbo].[pr_product](  --产品表
	[id] [int] IDENTITY(1,1) NOT NULL, --编号
	[category_id] [int] NULL,         --产品分类
	[bar_code] [nvarchar](20) NULL,   --条码
	[name] [varchar](50) NULL,        --名称
	[price] [money] NULL,             --价格
	[stock] [decimal](18, 2) NULL,    --库存
	[license_no] [varchar](50) NULL,  --批文
	[spec] [varchar](200) NULL,       --规格
	[unit] [varchar](50) NULL,        --单位
	[place] [varchar](200) NULL,      --产地
	[manufacturer] [varchar](200) NOT NULL,--生产厂家
	[operator_id] [int] NULL,              --操作人
	[operator_time] [datetime] NULL,       --操作时间
	[remark] [varchar](200) NULL           --备注
) 
CREATE TABLE [dbo].[pr_product_category](--产品类别表
	[id] [int] IDENTITY(1,1) NOT NULL,   --编号
	[name] [varchar](50) NULL,           --名称
	[remark] [varchar](200) NULL         --备注
) 
CREATE TABLE [dbo].[pr_product_material]( --产品材料表
	[id] [int] IDENTITY(1,1) NOT NULL,    --编号
	[task_id] [int] NULL,                 --生产任务
	[commodity_id] [int] NULL,            --物料编号
	[nums] [int] NULL,                    --数量
	[uses] [varchar](200) NULL,           --用途
	[department_id] [int] NULL,           --领用部门
	[staff_id] [int] NULL,                --领用人
	[receipt_date] [decimal](18, 0) NULL, --领用日期
	[operator_id] [int] NULL,             --操作人
	[operate_time] [datetime] NULL,       --操作时间
	[status] [int] NULL,                  --状态
	[remark] [varchar](200) NULL          --备注
)
CREATE TABLE [dbo].[pr_product_task](--产品任务表
	[id] [int] IDENTITY(1,1) NOT NULL, --编号
	[no] [varchar](200) NULL,          --生产单号
	[product_id] [int] NULL,           --产品编号
	[nums] [decimal](18, 2) NULL,      --数量
	[product_date] [date] NULL,        --生产日期
	[batch] [varchar](20) NULL,        --批次号
	[department_id] [int] NULL,        --部门编号
	[operator_id] [int] NULL,          --操作人供应商编号
	[operate_time] [datetime] NULL,    --操作时间
	[status] [int] NULL,               --状态
	[remark] [varchar](200) NULL,      --备注
	[qm_id] [int] NULL,                --质检编号
) 
CREATE TABLE [dbo].[pu_commodity](    --商品表  原材料表
	[id] [int] IDENTITY(1,1) NOT NULL,--编号
	[category_id] [int] NULL,         --分类编号
	[supplier_id] [int] NULL,         --供应商编号
	[name] [nvarchar](50) NULL,       --名称
	[price] [money] NULL,             --价格
	[stock] [decimal](18, 2) NULL,    --库存
	[place] [nvarchar](200) NULL,     --产地
	[spec] [nvarchar](20) NULL,       --规格
	[license_no] [nvarchar](50) NULL, --生产批文
	[operator_id] [int] NULL,         --操作人
	[operate_time] [datetime] NULL,   --操作时间
	[remark] [nvarchar](200) NULL     --备注
)

CREATE TABLE [dbo].[pu_commodity_category]( --原材料类别表
	[id] [int] IDENTITY(1,1) NOT NULL,      --编号
	[name] [varchar](50) NULL,              --名称
	[remark] [varchar](200) NULL            --备注
) 

CREATE TABLE [dbo].[pu_order](         --订单表
	[id] [int] IDENTITY(1,1) NOT NULL, --编号
	[no] [nvarchar](50) NULL,          --订单号
	[commodity_id] [int] NULL,         --商品编号
	[nums] [decimal](18, 2) NULL,      --数量
	[purchase_date] [date] NULL,       --采购时间
	[batch] [nchar](10) NULL,          --批次号
	[amount] [money] NULL,             --金额
	[amount_way] [int] NULL,           --结算方式
	[amount_receivable] [money] NULL,  --应收金额
	[amount_received] [money] NULL,    --实收金额
	[handle_id] [int] NULL,            --经手人
	[operator_id] [int] NULL,          --操作人
	[operate_time] [datetime] NULL,    --操作时间
	[status] [int] NULL,               --状态
	[qm_id] [int] NULL,                --质检单编号
	[remark] [nvarchar](200) NULL,     --备注
) 
CREATE TABLE [dbo].[pu_supplier](       --供应商表
	[id] [int] IDENTITY(1,1) NOT NULL,  --编号
	[name] [varchar](100) NULL,         --名称
	[postcode] [nvarchar](20) NULL,     --邮编
	[address] [nvarchar](200) NULL,     --地址
	[linkman] [nvarchar](50) NULL,      --联系人
	[tel] [nvarchar](50) NULL,          --电话
	[qq] [nvarchar](20) NULL,           --QQ
	[weixin] [nvarchar](20) NULL,       --微信
	[email] [nvarchar](20) NULL,        --邮箱
	[credit] [nvarchar](50) NULL,       --信誉度
	[remark] [nvarchar](200) NULL,      --备注
	[operator_id] [int] NULL,           --操作人 
	[operate_time] [datetime] NULL      --操作时间
) 


CREATE TABLE [dbo].[qm_commodity](     --质检商品表
	[id] [int] IDENTITY(1,1) NOT NULL, --编号
	[no] [varchar](20) NULL,           --质检单号
	[order_id] [int] NULL,             --采购单编号
	[qm_date] [date] NULL,             --质检日期
	[result] [int] NULL,               --结论
	[handle_id] [int] NULL,            --经手人
	[operator_id] [int] NULL,          --操作人
	[operate_time] [datetime] NULL,    --操作时间
	[pic] [varchar](200) NULL,         --图片
	[remark] [varchar](200) NULL       --备注
)
CREATE TABLE [dbo].[qm_product](       --质检产品表
	[id] [int] IDENTITY(1,1) NOT NULL, --编号
	[no] [varchar](20) NULL,           --质检单号
	[task_id] [int] NULL,              --生产单编号
	[qm_date] [date] NULL,             --质检日期
	[result] [int] NULL,               --质检结论
	[handle_id] [int] NULL,            --经手人
	[operator_id] [int] NULL,          --操作人
	[operate_time] [datetime] NULL,    --操作时间
	[pic] [varchar](200) NULL,         --质检图片
	[remark] [varchar](200) NULL,      --备注
)
CREATE TABLE [dbo].[sl_customer](      --顾客表
	[id] [int] IDENTITY(1,1) NOT NULL, --编号
	[name] [varchar](50) NOT NULL,     --姓名
	[postcode] [nchar](10) NULL,       --邮编
	[address] [varchar](100) NULL,     --地址
	[custtel] [varchar](50) NOT NULL,  --客户电话
	[linkman] [varchar](50) NULL,      --联系人
	[linktel] [varchar](50) NULL,      --联系方式
	[email] [varchar](32) NULL,        --邮箱
	[sex] [bit] NULL,                  --性别
	[birthday] [date] NULL,            --生日
	[love] [varchar](50) NULL,         --爱好
	[remark] [varchar](200) NULL       --备注
)
CREATE TABLE [dbo].[sl_order](          --si订单表
	[id] [int] IDENTITY(1,1) NOT NULL,  --编号
	[no] [nvarchar](20) NOT NULL,       --订单编号
	[customer_id] [int] NOT NULL,       --客户编号
	[product_id] [int] NOT NULL,        --产品编号
	[nums] [decimal](10, 2) NOT NULL,   --数量
	[price] [decimal](10, 2) NULL,      --单价
	[delivery_date] [date] NULL,        --交货日期
	[delivery_way] [nvarchar](20) NULL, --交货方式
	[order_date] [date] NULL,           --下单时间
	[order_amount] [decimal](18, 2) NULL,--订单金额
	[handle_id] [int] NULL,             --经手人
	[operator_id] [int] NULL,           -- 操作员
	[operator_time] [datetime] NULL,    --操作时间
	[status] [int] NULL,                --状态(0待审核，1已审核，2待发货，3已出库，-1审核不通过)
	[remark] [nvarchar](200) NULL       --备注
)
CREATE TABLE [dbo].[sl_reject](        --退货单表
	[id] [int] IDENTITY(1,1) NOT NULL, --编号
	[no] [nvarchar](50) NULL,          --退货单号
	[order_id] [int] NULL,             --订单号
	[sale_order_id] [int] NULL,        --销售单号
	[customer_id] [int] NULL,          -- 客户
	[product_id] [int] NULL,           --产品
	[reject_date] [date] NULL,         --退单日期
	[nums] [decimal](18, 2) NULL,      --数量
	[amount] [decimal](18, 2) NULL,    --金额
	[amount_way] [varchar](20) NULL,   --结算方式
	[handle_id] [int] NULL,            --经手人
	[operator_id] [int] NULL,          --操作人
	[operator_time] [datetime] NULL,   --操作时间
	[approval_status] [int] NULL,      --审批状态
	[return_status] [int] NULL,        --退单状态
	[remark] [nvarchar](200) NULL,     --备注
)
CREATE TABLE [dbo].[sl_sale_order](              --销售订单表
	[id] [int] NOT NULL,                         --编号
	[no] [nvarchar](50) NULL,                    --销售编号
	[product_id] [int] NULL,                     --产品
	[customer_id] [int] NULL,                    --客户编号
	[order_id] [int] NULL,                       --订单
	[sale_date] [date] NULL,                     --销售日期
	[nums] [decimal](18, 2) NULL,                --销售数量
	[amount] [decimal](18, 2) NULL,              --总金额
	[amount_way] [varchar](20) NULL,             --结算方式
	[amount_receivable] [decimal](18, 2) NULL,   --应收金额
	[amount_received] [decimal](18, 2) NULL,     --实收金额
	[handle_id] [int] NULL,                      --经手人
	[operator_id] [int] NULL,                    --操作人
	[operator_time] [datetime] NULL,             --操作时间
	[audit_status] [int] NULL,                   --审批状态  0待审批  1已审批  -1审批不通过
	[order_status] [int] NULL,                   --订单状态  0待提货  1 已出库
	[Remark] [nvarchar](200) NULL,               --备注
) 
CREATE TABLE [dbo].[sys_config_Item](    --配置项表
	[id] [int] IDENTITY(1,1) NOT NULL,   --编号
	[keyword] [nvarchar](50) NULL,       --关键字
	[table_name] [nvarchar](50) NULL,    --表名
	[field_name] [nvarchar](50) NULL,    --字段名
	[option_value] [int] NULL,           --值
	[option_text] [nvarchar](50) NULL,   --文本
	[sorting] [int] NULL,                --排序
	[status] [int] NULL,                 --状态
) 


