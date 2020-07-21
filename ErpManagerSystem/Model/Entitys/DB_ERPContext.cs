using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model.Entitys
{
    public partial class DB_ERPContext : DbContext
    {

        public DB_ERPContext(DbContextOptions<DB_ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcDepartment> AcDepartment { get; set; }
        public virtual DbSet<AcPermission> AcPermission { get; set; }
        public virtual DbSet<AcRole> AcRole { get; set; }
        public virtual DbSet<AcRolePermission> AcRolePermission { get; set; }
        public virtual DbSet<AcStaff> AcStaff { get; set; }
        public virtual DbSet<AcUserInfo> AcUserInfo { get; set; }
        public virtual DbSet<AuRecord> AuRecord { get; set; }
        public virtual DbSet<IcCommodityRecord> IcCommodityRecord { get; set; }
        public virtual DbSet<IcCommodityStock> IcCommodityStock { get; set; }
        public virtual DbSet<IcProductRecord> IcProductRecord { get; set; }
        public virtual DbSet<IcProductStock> IcProductStock { get; set; }
        public virtual DbSet<IcWarehouse> IcWarehouse { get; set; }
        public virtual DbSet<PrProduct> PrProduct { get; set; }
        public virtual DbSet<PrProductCategory> PrProductCategory { get; set; }
        public virtual DbSet<PrProductMaterial> PrProductMaterial { get; set; }
        public virtual DbSet<PrProductTask> PrProductTask { get; set; }
        public virtual DbSet<PuCommodity> PuCommodity { get; set; }
        public virtual DbSet<PuCommodityCategory> PuCommodityCategory { get; set; }
        public virtual DbSet<PuOrder> PuOrder { get; set; }
        public virtual DbSet<PuSupplier> PuSupplier { get; set; }
        public virtual DbSet<QmCommodity> QmCommodity { get; set; }
        public virtual DbSet<QmProduct> QmProduct { get; set; }
        public virtual DbSet<SlCustomer> SlCustomer { get; set; }
        public virtual DbSet<SlOrder> SlOrder { get; set; }
        public virtual DbSet<SlReject> SlReject { get; set; }
        public virtual DbSet<SlSaleOrder> SlSaleOrder { get; set; }
        public virtual DbSet<SysConfigItem> SysConfigItem { get; set; }
        public virtual DbSet<ViewUserPermission> ViewUserPermission { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcDepartment>(entity =>
            {
                entity.ToTable("ac_department");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .HasComment("名称");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .HasComment("备注");
            });

            modelBuilder.Entity<AcPermission>(entity =>
            {
                entity.ToTable("ac_permission");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(50)
                    .HasComment("菜单图标");

                entity.Property(e => e.IsMenu)
                    .HasColumnName("is_menu")
                    .HasComment("是否菜单");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .HasComment("名称");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasComment("上级权限");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .HasComment("备注");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(50)
                    .HasComment("URL");
            });

            modelBuilder.Entity<AcRole>(entity =>
            {
                entity.ToTable("ac_role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .HasComment("名称");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .HasComment("备注");
            });

            modelBuilder.Entity<AcRolePermission>(entity =>
            {
                entity.ToTable("ac_role_permission");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permission_id")
                    .HasComment("权限编号");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasComment("角色编号");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AcRolePermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ac_role_permission_ac_permission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AcRolePermission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ac_role_permission_ac_role");
            });

            modelBuilder.Entity<AcStaff>(entity =>
            {
                entity.ToTable("ac_staff");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .HasComment("地址");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasComment("部门");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .HasComment("姓名");

                entity.Property(e => e.No)
                    .IsRequired()
                    .HasColumnName("no")
                    .HasMaxLength(10)
                    .HasComment("员工编号");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .HasComment("备注");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasComment("0：男，1：女");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("0：离职，1：在职");

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(21)
                    .HasComment("电话");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasComment("账户id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AcStaff)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_ac_staff_ac_department");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AcStaff)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ac_staff_ac_userInfo");
            });

            modelBuilder.Entity<AcUserInfo>(entity =>
            {
                entity.ToTable("ac_userInfo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasMaxLength(20)
                    .HasComment("账号");

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasMaxLength(50)
                    .HasComment("密码");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasComment("角色编号");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasComment("员工编号");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AcUserInfo)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_ac_userInfo_ac_role");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.AcUserInfo)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_ac_userInfo_ac_staff");
            });

            modelBuilder.Entity<AuRecord>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Shura_EXAMINATIONS")
                    .IsClustered(false);

                entity.ToTable("au_record");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.ApproveDesc)
                    .HasColumnName("approve_desc")
                    .HasColumnType("datetime")
                    .HasComment("处理备注");

                entity.Property(e => e.ApproveReult)
                    .HasColumnName("approve_reult")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("处理结论");

                entity.Property(e => e.ApproveTime)
                    .HasColumnName("approve_time")
                    .HasColumnType("datetime")
                    .HasComment("处理时间");

                entity.Property(e => e.ApproverId)
                    .HasColumnName("approver_id")
                    .HasComment("处理人");

                entity.Property(e => e.OperateDesc)
                    .HasColumnName("operate_desc")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("操作意见");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("备注");

                entity.Property(e => e.SourceId)
                    .HasColumnName("source_id")
                    .HasComment("审批单号");

                entity.Property(e => e.SourceType)
                    .HasColumnName("source_type")
                    .HasComment("审批类型");

                entity.HasOne(d => d.Approver)
                    .WithMany(p => p.AuRecordApprover)
                    .HasForeignKey(d => d.ApproverId)
                    .HasConstraintName("FK_au_record_ac_staff1");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.AuRecordOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_au_record_ac_staff");
            });

            modelBuilder.Entity<IcCommodityRecord>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Shura_GOODSINANDOUTS")
                    .IsClustered(false);

                entity.ToTable("ic_commodity_record");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("批次号");

                entity.Property(e => e.CommodityId)
                    .HasColumnName("commodity_id")
                    .HasComment("商品");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasComment("出入库部门");

                entity.Property(e => e.IsIn)
                    .HasColumnName("is_in")
                    .HasComment("出入库");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .HasComment("主题");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("数量");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("原因");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("备注");

                entity.Property(e => e.SourceCategory)
                    .HasColumnName("source_category")
                    .HasComment("源单类型");

                entity.Property(e => e.SourceId)
                    .HasColumnName("source_id")
                    .HasComment("源单ID");

                entity.Property(e => e.SourceNo)
                    .HasColumnName("source_no")
                    .HasMaxLength(50)
                    .HasComment("源单编号");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasComment("出入库员工");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.WarehouseId)
                    .HasColumnName("warehouse_id")
                    .HasComment("仓库");

                entity.HasOne(d => d.Commodity)
                    .WithMany(p => p.IcCommodityRecord)
                    .HasForeignKey(d => d.CommodityId)
                    .HasConstraintName("FK_ic_commodity_record_pu_commodity");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.IcCommodityRecord)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_ic_commodity_record_ac_department");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.IcCommodityRecordOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_ic_commodity_record_ac_staff1");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.IcCommodityRecordStaff)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_ic_commodity_record_ac_staff");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.IcCommodityRecord)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("FK_ic_commodity_record_ic_warehouse");
            });

            modelBuilder.Entity<IcCommodityStock>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Shura_GOODSWAREHOUSES")
                    .IsClustered(false);

                entity.ToTable("ic_commodity_stock");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.CommodityId)
                    .HasColumnName("commodity_id")
                    .HasComment("商品编号");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .HasComment("备注");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("库存");

                entity.Property(e => e.WarehouseId)
                    .HasColumnName("warehouse_id")
                    .HasComment("仓库");

                entity.HasOne(d => d.Commodity)
                    .WithMany(p => p.IcCommodityStock)
                    .HasForeignKey(d => d.CommodityId)
                    .HasConstraintName("FK_ic_commodity_stock_pu_commodity");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.IcCommodityStock)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("FK_ic_commodity_stock_ic_warehouse");
            });

            modelBuilder.Entity<IcProductRecord>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ic_product_record");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("批次号");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasComment("部门编号");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IsIn)
                    .HasColumnName("is_in")
                    .HasComment("出入库");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .HasComment("名称");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("数量");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("产品编号");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("原因");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SourceCategory)
                    .HasColumnName("source_category")
                    .HasComment("源单类型");

                entity.Property(e => e.SourceId)
                    .HasColumnName("source_id")
                    .HasComment("源单编号");

                entity.Property(e => e.SourceNo)
                    .HasColumnName("source_no")
                    .HasMaxLength(50)
                    .HasComment("原单订单号");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasComment("员工编号");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.WarehouseId)
                    .HasColumnName("warehouse_id")
                    .HasComment("仓库编号");

                entity.HasOne(d => d.Department)
                    .WithMany()
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_ic_product_record_ac_department");

                entity.HasOne(d => d.Operator)
                    .WithMany()
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_ic_product_record_ac_staff1");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ic_product_record_pr_product");

                entity.HasOne(d => d.Staff)
                    .WithMany()
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_ic_product_record_ac_staff");

                entity.HasOne(d => d.Warehouse)
                    .WithMany()
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("FK_ic_product_record_ic_warehouse");
            });

            modelBuilder.Entity<IcProductStock>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Shura_PRODUCTWAREHOUSES")
                    .IsClustered(false);

                entity.ToTable("ic_product_stock");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("产品编号");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .HasComment("备注");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("库存数");

                entity.Property(e => e.WarehouseId)
                    .HasColumnName("warehouse_id")
                    .HasComment("仓库号");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.IcProductStock)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ic_product_stock_pr_product");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.IcProductStock)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("FK_ic_product_stock_ic_warehouse");
            });

            modelBuilder.Entity<IcWarehouse>(entity =>
            {
                entity.ToTable("ic_warehouse");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(200)
                    .HasComment("地址");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasComment("仓库类型");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("manager_id")
                    .HasComment("管理员");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasComment("名称");

                entity.Property(e => e.No)
                    .IsRequired()
                    .HasColumnName("no")
                    .HasMaxLength(50)
                    .HasComment("仓库编号");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .HasComment("备注");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");
            });

            modelBuilder.Entity<PrProduct>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Shura_PRODUCTS")
                    .IsClustered(false);

                entity.ToTable("pr_product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.BarCode)
                    .HasColumnName("bar_code")
                    .HasMaxLength(20)
                    .HasComment("条码");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasComment("产品分类");

                entity.Property(e => e.LicenseNo)
                    .HasColumnName("license_no")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("批文");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasColumnName("manufacturer")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("生产厂家");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("名称");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.OperatorTime)
                    .HasColumnName("operator_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.Place)
                    .HasColumnName("place")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("产地");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money")
                    .HasComment("价格");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("备注");

                entity.Property(e => e.Spec)
                    .HasColumnName("spec")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("规格");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))")
                    .HasComment("库存");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("单位");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PrProduct)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_pr_product_pr_product_category");
            });

            modelBuilder.Entity<PrProductCategory>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Shura_PRODUCTCATEGORYS")
                    .IsClustered(false);

                entity.ToTable("pr_product_category");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("名称");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("备注");
            });

            modelBuilder.Entity<PrProductMaterial>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Shura_MATERIALS")
                    .IsClustered(false);

                entity.ToTable("pr_product_material");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.CommodityId)
                    .HasColumnName("commodity_id")
                    .HasComment("物料编号");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasComment("领用部门");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasComment("数量");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnName("receipt_date")
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("领用日期");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("备注");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasComment("领用人");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasComment("生产任务");

                entity.Property(e => e.Uses)
                    .HasColumnName("uses")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("用途");

                entity.HasOne(d => d.Commodity)
                    .WithMany(p => p.PrProductMaterial)
                    .HasForeignKey(d => d.CommodityId)
                    .HasConstraintName("FK_pr_product_material_pu_commodity");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.PrProductMaterial)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_pr_product_material_ac_department");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.PrProductMaterialOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_pr_product_material_ac_staff1");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.PrProductMaterialStaff)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_pr_product_material_ac_staff");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.PrProductMaterial)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_pr_product_material_pr_product_task");
            });

            modelBuilder.Entity<PrProductTask>(entity =>
            {
                entity.ToTable("pr_product_task");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("批次号");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasComment("部门编号");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("生产单号");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("数量");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.ProductDate)
                    .HasColumnName("product_date")
                    .HasColumnType("date")
                    .HasComment("生产日期");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("产品编号");

                entity.Property(e => e.QmId)
                    .HasColumnName("qm_id")
                    .HasComment("质检编号");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("备注");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.PrProductTask)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_pr_product_task_ac_staff");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PrProductTask)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_pr_product_task_ac_department");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.PrProductTask)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_pr_product_task_pr_product");

                entity.HasOne(d => d.Qm)
                    .WithMany(p => p.PrProductTask)
                    .HasForeignKey(d => d.QmId)
                    .HasConstraintName("FK_pr_product_task_qm_product");
            });

            modelBuilder.Entity<PuCommodity>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Shura_GOODS")
                    .IsClustered(false);

                entity.ToTable("pu_commodity");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasComment("分类编号");

                entity.Property(e => e.LicenseNo)
                    .HasColumnName("license_no")
                    .HasMaxLength(50)
                    .HasComment("生产批文");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .HasComment("名称");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.Place)
                    .HasColumnName("place")
                    .HasMaxLength(200)
                    .HasComment("产地");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money")
                    .HasComment("价格");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .HasComment("备注");

                entity.Property(e => e.Spec)
                    .HasColumnName("spec")
                    .HasMaxLength(20)
                    .HasComment("规格");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))")
                    .HasComment("库存");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("supplier_id")
                    .HasComment("供应商编号");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PuCommodity)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_pu_commodity_pu_commodity_category");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.PuCommodity)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_pu_commodity_ac_staff");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.PuCommodity)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_pu_commodity_pu_supplier");
            });

            modelBuilder.Entity<PuCommodityCategory>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Shura_GOODSTCATEGORYS")
                    .IsClustered(false);

                entity.ToTable("pu_commodity_category");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("名称");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("备注");
            });

            modelBuilder.Entity<PuOrder>(entity =>
            {
                entity.ToTable("pu_order");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money")
                    .HasComment("金额");

                entity.Property(e => e.AmountReceivable)
                    .HasColumnName("amount_receivable")
                    .HasColumnType("money")
                    .HasComment("应收金额");

                entity.Property(e => e.AmountReceived)
                    .HasColumnName("amount_received")
                    .HasColumnType("money")
                    .HasComment("实收金额");

                entity.Property(e => e.AmountWay)
                    .HasColumnName("amount_way")
                    .HasComment("结算方式");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("批次号");

                entity.Property(e => e.CommodityId)
                    .HasColumnName("commodity_id")
                    .HasComment("商品编号");

                entity.Property(e => e.HandleId)
                    .HasColumnName("handle_id")
                    .HasComment("经手人");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasMaxLength(50)
                    .HasComment("订单号");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("数量");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnName("purchase_date")
                    .HasColumnType("date")
                    .HasComment("采购时间");

                entity.Property(e => e.QmId)
                    .HasColumnName("qm_id")
                    .HasComment("质检单编号");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .HasComment("备注");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.HasOne(d => d.Commodity)
                    .WithMany(p => p.PuOrder)
                    .HasForeignKey(d => d.CommodityId)
                    .HasConstraintName("FK_pu_order_pu_commodity");

                entity.HasOne(d => d.Handle)
                    .WithMany(p => p.PuOrder)
                    .HasForeignKey(d => d.HandleId)
                    .HasConstraintName("FK_pu_order_ac_staff");

                entity.HasOne(d => d.Qm)
                    .WithMany(p => p.PuOrder)
                    .HasForeignKey(d => d.QmId)
                    .HasConstraintName("FK_pu_order_qm_commodity");
            });

            modelBuilder.Entity<PuSupplier>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Shura_SUPPLIERS")
                    .IsClustered(false);

                entity.ToTable("pu_supplier");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(200)
                    .HasComment("地址");

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasMaxLength(50)
                    .HasComment("信誉度");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(20)
                    .HasComment("邮箱");

                entity.Property(e => e.Linkman)
                    .HasColumnName("linkman")
                    .HasMaxLength(50)
                    .HasComment("联系人");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("名称");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.OperatorId).HasColumnName("operator_id");

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasMaxLength(20)
                    .HasComment("邮编");

                entity.Property(e => e.Qq)
                    .HasColumnName("qq")
                    .HasMaxLength(20)
                    .HasComment("QQ");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .HasComment("备注");

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(50)
                    .HasComment("电话");

                entity.Property(e => e.Weixin)
                    .HasColumnName("weixin")
                    .HasMaxLength(20)
                    .HasComment("微信");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.PuSupplier)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_pu_supplier_ac_staff");
            });

            modelBuilder.Entity<QmCommodity>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Shura_GOODSQUALITIES")
                    .IsClustered(false);

                entity.ToTable("qm_commodity");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.HandleId)
                    .HasColumnName("handle_id")
                    .HasComment("经手人");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("质检单号");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasComment("采购单编号");

                entity.Property(e => e.Pic)
                    .HasColumnName("pic")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("图片");

                entity.Property(e => e.QmDate)
                    .HasColumnName("qm_date")
                    .HasColumnType("date")
                    .HasComment("质检日期");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("备注");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasComment("结论");

                entity.HasOne(d => d.Handle)
                    .WithMany(p => p.QmCommodityHandle)
                    .HasForeignKey(d => d.HandleId)
                    .HasConstraintName("FK_qm_commodity_ac_staff");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.QmCommodityOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_qm_commodity_ac_staff1");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.QmCommodity)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_qm_commodity_pu_order");
            });

            modelBuilder.Entity<QmProduct>(entity =>
            {
                entity.ToTable("qm_product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.HandleId)
                    .HasColumnName("handle_id")
                    .HasComment("经手人");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("质检单号");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.Pic)
                    .HasColumnName("pic")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("质检图片");

                entity.Property(e => e.QmDate)
                    .HasColumnName("qm_date")
                    .HasColumnType("date")
                    .HasComment("质检日期");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("备注");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasComment("质检结论");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasComment("生产单编号");

                entity.HasOne(d => d.Handle)
                    .WithMany(p => p.QmProductHandle)
                    .HasForeignKey(d => d.HandleId)
                    .HasConstraintName("FK_qm_product_ac_staff");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.QmProductOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_qm_product_ac_staff1");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.QmProduct)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_qm_product_pr_product_task");
            });

            modelBuilder.Entity<SlCustomer>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Shura_CUSTOMERS")
                    .IsClustered(false);

                entity.ToTable("sl_customer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("地址");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date")
                    .HasComment("生日");

                entity.Property(e => e.Custtel)
                    .IsRequired()
                    .HasColumnName("custtel")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("客户电话");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasComment("邮箱");

                entity.Property(e => e.Linkman)
                    .HasColumnName("linkman")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("联系人");

                entity.Property(e => e.Linktel)
                    .HasColumnName("linktel")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("联系方式");

                entity.Property(e => e.Love)
                    .HasColumnName("love")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("爱好");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("姓名");

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("邮编");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("备注");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasComment("性别");
            });

            modelBuilder.Entity<SlOrder>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Shura_ORDERS")
                    .IsClustered(false);

                entity.ToTable("sl_order");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasComment("客户编号");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("delivery_date")
                    .HasColumnType("date")
                    .HasComment("交货日期");

                entity.Property(e => e.DeliveryWay)
                    .HasColumnName("delivery_way")
                    .HasMaxLength(20)
                    .HasComment("交货方式");

                entity.Property(e => e.HandleId)
                    .HasColumnName("handle_id")
                    .HasComment("经手人");

                entity.Property(e => e.No)
                    .IsRequired()
                    .HasColumnName("no")
                    .HasMaxLength(20)
                    .HasComment("订单编号");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(10, 2)")
                    .HasComment("数量");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作员");

                entity.Property(e => e.OperatorTime)
                    .HasColumnName("operator_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OrderAmount)
                    .HasColumnName("order_amount")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("订单金额");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("date")
                    .HasComment("下单时间");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10, 2)")
                    .HasComment("单价");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("产品编号");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .HasComment("备注");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态(0待审核，1已审核，2待发货，3已出库，-1审核不通过)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SlOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sl_order_sl_customer");

                entity.HasOne(d => d.Handle)
                    .WithMany(p => p.SlOrderHandle)
                    .HasForeignKey(d => d.HandleId)
                    .HasConstraintName("FK_sl_order_ac_staff");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.SlOrderOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_sl_order_ac_staff1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SlOrder)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sl_order_pr_product");
            });

            modelBuilder.Entity<SlReject>(entity =>
            {
                entity.ToTable("sl_reject");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("金额");

                entity.Property(e => e.AmountWay)
                    .HasColumnName("amount_way")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("结算方式");

                entity.Property(e => e.ApprovalStatus)
                    .HasColumnName("approval_status")
                    .HasComment("审批状态");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasComment("客户");

                entity.Property(e => e.HandleId)
                    .HasColumnName("handle_id")
                    .HasComment("经手人");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasMaxLength(50)
                    .HasComment("退货单号");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("数量");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.OperatorTime)
                    .HasColumnName("operator_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasComment("订单号");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("产品");

                entity.Property(e => e.RejectDate)
                    .HasColumnName("reject_date")
                    .HasColumnType("date")
                    .HasComment("退单日期");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(200)
                    .HasComment("备注");

                entity.Property(e => e.ReturnStatus)
                    .HasColumnName("return_status")
                    .HasComment("退单状态");

                entity.Property(e => e.SaleOrderId)
                    .HasColumnName("sale_order_id")
                    .HasComment("销售单号");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SlReject)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_sl_reject_sl_customer");

                entity.HasOne(d => d.Handle)
                    .WithMany(p => p.SlRejectHandle)
                    .HasForeignKey(d => d.HandleId)
                    .HasConstraintName("FK_sl_reject_ac_staff");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.SlRejectOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_sl_reject_ac_staff1");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.SlReject)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_sl_reject_sl_order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SlReject)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_sl_reject_pr_product");

                entity.HasOne(d => d.SaleOrder)
                    .WithMany(p => p.SlReject)
                    .HasForeignKey(d => d.SaleOrderId)
                    .HasConstraintName("FK_sl_reject_sl_sale_order");
            });

            modelBuilder.Entity<SlSaleOrder>(entity =>
            {
                entity.ToTable("sl_sale_order");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("总金额");

                entity.Property(e => e.AmountReceivable)
                    .HasColumnName("amount_receivable")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("应收金额");

                entity.Property(e => e.AmountReceived)
                    .HasColumnName("amount_received")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("实收金额");

                entity.Property(e => e.AmountWay)
                    .HasColumnName("amount_way")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("结算方式");

                entity.Property(e => e.AuditStatus)
                    .HasColumnName("audit_status")
                    .HasComment("审批状态  0待审批  1已审批  -1审批不通过");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasComment("客户编号");

                entity.Property(e => e.HandleId)
                    .HasColumnName("handle_id")
                    .HasComment("经手人");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasMaxLength(50)
                    .HasComment("销售编号");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("销售数量");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.OperatorTime)
                    .HasColumnName("operator_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasComment("订单");

                entity.Property(e => e.OrderStatus)
                    .HasColumnName("order_status")
                    .HasComment("0待提货  1 已出库");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("产品");

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .HasComment("备注");

                entity.Property(e => e.SaleDate)
                    .HasColumnName("sale_date")
                    .HasColumnType("date")
                    .HasComment("销售日期");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SlSaleOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_sl_sale_order_sl_customer");

                entity.HasOne(d => d.Handle)
                    .WithMany(p => p.SlSaleOrderHandle)
                    .HasForeignKey(d => d.HandleId)
                    .HasConstraintName("FK_sl_sale_order_ac_staff");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.SlSaleOrderOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_sl_sale_order_ac_staff1");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.SlSaleOrder)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_sl_sale_order_sl_order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SlSaleOrder)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_sl_sale_order_pr_product");
            });

            modelBuilder.Entity<SysConfigItem>(entity =>
            {
                entity.ToTable("sys_config_Item");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.FieldName)
                    .HasColumnName("field_name")
                    .HasMaxLength(50)
                    .HasComment("字段名");

                entity.Property(e => e.Keyword)
                    .HasColumnName("keyword")
                    .HasMaxLength(50)
                    .HasComment("关键字");

                entity.Property(e => e.OptionText)
                    .HasColumnName("option_text")
                    .HasMaxLength(50)
                    .HasComment("文本");

                entity.Property(e => e.OptionValue)
                    .HasColumnName("option_value")
                    .HasComment("值");

                entity.Property(e => e.Sorting)
                    .HasColumnName("sorting")
                    .HasComment("排序");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasMaxLength(50)
                    .HasComment("表名");
            });

            modelBuilder.Entity<ViewUserPermission>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_User_Permission");

                entity.Property(e => e.Account).HasMaxLength(20);

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsMenu).HasColumnName("is_menu");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pwd).HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Url).HasMaxLength(50);

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
