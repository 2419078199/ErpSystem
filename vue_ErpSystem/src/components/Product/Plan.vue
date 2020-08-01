<template>
  <div>
    <el-row :gutter="20">
      <el-col :span="6">
        <el-input
          placeholder="产品名称或计划编号或订单编号"
          v-model="queryInfo.searchInfo"
          class="input-with-select"
        >
          <el-button slot="append" icon="el-icon-search" @click="btnSearch"></el-button>
        </el-input>
      </el-col>
      <el-col :span="6">
        <el-button type="primary" @click="AddProductPlan = true">新增计划</el-button>
      </el-col>
    </el-row>
    <el-table :data="tableData" border style="width: 100%">
      <el-table-column fixed prop="id" label="编号" width="100"></el-table-column>
      <el-table-column prop="batch" label="计划编号" width="150"></el-table-column>
      <el-table-column prop="productName" label="产品名称" width="120"></el-table-column>
      <el-table-column prop="nums" label="计划产量" width="120"></el-table-column>
      <el-table-column prop="productDate" label="计划生产时间" width="300">
        <template v-slot="scope">{{scope.row.productDate | dateFormat}}</template>
      </el-table-column>
      <el-table-column prop="operatorName" label="操作人" width="120"></el-table-column>
      <el-table-column prop="no" label="订单编号" width="150"></el-table-column>
      <el-table-column prop="status" label="状态" width="120"></el-table-column>
      <el-table-column fixed="right" label="操作" width="180">
        <template slot-scope="scope">
          <el-button icon="el-icon-search" circle></el-button>
          <el-button
            type="primary"
            icon="el-icon-edit"
            circle
            @click="Edit(scope.$index, tableData)"
          ></el-button>
          <el-button
            type="danger"
            icon="el-icon-delete"
            circle
            @click="delPlan(scope.$index, tableData)"
          ></el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-dialog title="添加产品计划" :visible.sync="AddProductPlan">
      <el-form :model="addPlan" :rules="addPlanRules" ref="addPlan">
        <el-form-item label="订单号" :label-width="formLabelWidth">
          <el-select v-model="addPlan.No" filterable placeholder="请选择">
            <el-option v-for="item in Orderno" :key="item.id" :label="item" :value="item"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item prop="ProductId" label="产品编号" :label-width="formLabelWidth">
          <el-input v-model="addPlan.ProductId" autocomplete="off" readonly="readonly"></el-input>
        </el-form-item>
        <el-form-item prop="ProductName" label="产品名称" :label-width="formLabelWidth">
          <el-input v-model="addPlan.ProductName" autocomplete="off" readonly="readonly"></el-input>
        </el-form-item>
        <el-form-item prop="Nums" label="计划产量" :label-width="formLabelWidth">
          <el-input v-model="addPlan.Nums" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item prop="productDate" label="计划开始时间" :label-width="formLabelWidth">
          <el-date-picker
            :picker-options="pickerOptions"
            v-model="addPlan.productDate"
            type="date"
            value-format=" yyyy-MM-dd HH:mm:ss"
            placeholder="选择日期时间"
          ></el-date-picker>
        </el-form-item>
        <el-form-item label="备注" :label-width="formLabelWidth">
          <el-input v-model="addPlan.Remark" autocomplete="off"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="AddProductPlan = false">取 消</el-button>
        <el-button type="primary" @click="add()">确 定</el-button>
      </div>
    </el-dialog>
    <el-dialog title="修改产品计划" :visible.sync="EditProductPlan">
      <el-form :model="EditPlan" :rules="EditPlanRules" ref="EditPlan">
        <el-form-item prop="nums" label="计划产量" :label-width="formLabelWidth">
          <el-input v-model="EditPlan.nums" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item prop="productDate" label="计划开始时间" :label-width="formLabelWidth">
          <el-date-picker
            v-model="EditPlan.productDate"
            :picker-options="pickerOptions"
            type="date"
            value-format="yyyy-MM-dd HH:mm:ss"
            placeholder="选择日期时间"
          ></el-date-picker>
        </el-form-item>
        <el-form-item label="备注" :label-width="formLabelWidth">
          <el-input v-model="EditPlan.remark" autocomplete="off"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="AddProductPlan = false">取 消</el-button>
        <el-button type="primary" @click="Editdialog()">确 定</el-button>
      </div>
    </el-dialog>
    <!-- 分页区域 -->
    <el-pagination
      background
      @size-change="handleSizeChange"
      @current-change="handleCurrentChange"
      :current-page="queryInfo.pageNum"
      :page-sizes="[5, 10, 15, 20]"
      :page-size="queryInfo.pageSize"
      layout="total, sizes, prev, pager, next, jumper"
      :total="totalCount"
    ></el-pagination>
  </div>
</template>

<script>
export default {
  methods: {
    Edit(index, data) {
      this.EditProductPlan = true;
      this.$axios
        .get("PrProductTask/GetPrProductTasksById/" + data[index].id)
        .then(response => (this.EditPlan = response.data.data))
        .catch(function(error) {
          // 请求失败处理
          console.log(error);
        });
    },
    Editdialog() {
      this.$refs.EditPlan.validate(async valid => {
        if (!valid) {
          return this.$message.error("请填写计划数量或时间");
        }
        this.$axios
          .put("PrProductTask/EditPrProductTask", this.EditPlan)
          .then(
            response => (
              this.$message.success("修改成功！"),
              (this.EditProductPlan = false),
              this.Loadpage()
            )
          )
          .catch(function(error) {
            // 请求失败处理
            this.$message.success("修改失败！"), (this.EditProductPlan = false);
          });
      });
    },
    async Loadpage() {
      const res = await this.$axios.get("PrProductTask/GetPrProductTasks", {
        params: this.queryInfo
      });
      const pagination = JSON.parse(res.headers["x-pagination"]);
      this.totalCount = pagination.totalCount;
      this.tableData = res.data.data;
    },
    //搜索订单
    btnSearch() {
      this.Loadpage();
    },
    delPlan(index, data) {
      this.$confirm("确认要删除该计划吗？", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      })
        .then(res => {
          this.$axios
            .delete("PrProductTask/DeletePrProductTask/" + data[index].id)
            .then(
              response => (
                this.$message.success("删除成功！！！"), this.Loadpage()
              )
            )
            .catch(function(error) {
              // 请求失败处理
              console.log(error);
              this.$message.success("删除失败！！！");
            });
        })
        .catch(err => err);
    },
    add() {
      this.$refs.addPlan.validate(async valid => {
        if (!valid) {
          return this.$message.error("请完善相关信息");
        }
        this.$axios
          .post("PrProductTask/AddPrProductTask", this.addPlan)
          .then(
            response => (
              this.$message.success("添加成功！！！"),
              (this.AddProductPlan = false),
              this.Loadpage()
            )
          )
          .catch(function(error) {
            // 请求失败处理
            console.log(error);
            this.$message.error("添加失败！！！");
          });
      });
    },
    //改变当前页
    handleCurrentChange(newNum) {
      this.queryInfo.pageNum = newNum;
      this.Loadpage();
    },
    //改变Size
    handleSizeChange(newSize) {
      this.queryInfo.pageSize = newSize;
      this.Loadpage();
    }
  },
  watch: {
    "addPlan.No"(newval, oldval) {
      this.$axios
        .get("SlOrder/GetOrderByNo/" + newval)
        .then(
          response => (
            (this.addPlan.ProductId = response.data.data.productId),
            (this.addPlan.ProductName = response.data.data.productName)
          )
        )
        .catch(function(error) {
          // 请求失败处理
          console.log(error);
        });
    },
    AddProductPlan(newval, oldval) {
      if (newval == true) {
        this.$axios
          .get("PrProductTask/GetOdernos")
          .then(response => (this.Orderno = response.data.data))
          .catch(function(error) {
            // 请求失败处理
            console.log(error);
          });
      }
    }
  },
  data() {
    return {
      pickerOptions: {
        //日期禁选项
        disabledDate(time) {
          return time.getTime() < Date.now() - 8.64e7; //当前时间以后可以选择当前时间
        }
      },
      queryInfo: {
        pageSize: 5,
        pageNum: 1,
        searchInfo: ""
      },
      totalCount: 0,
      tableData: [],
      AddProductPlan: false,
      EditProductPlan: false,
      Orderid: "",
      Orderno: [],
      addPlan: {
        No: "",
        ProductId: null,
        ProductName: "",
        productDate: "",
        Nums: 0,
        Remark: ""
      },
      //添加计划表单的校验规则
      addPlanRules: {
        ProductName: [
          { required: true, message: "请选择订单编号", trigger: "blur" }
        ],
        ProductId: [
          { required: true, message: "请选择订单编号", trigger: "blur" }
        ],
        productDate: [
          { required: true, message: "请选择开始时间", trigger: "blur" }
        ],
        Nums: [{ required: true, message: "请输入计划产量", trigger: "blur" }]
      },
      EditPlan: {
        id: 0,
        no: "",
        productId: null,
        productDate: "",
        nums: 0,
        batch: "",
        departmentId: 0,
        operatorId: 0,
        operateTime: "",
        status: "",
        remark: ""
      },
      //修改计划表单的校验规则
      EditPlanRules: {
        productDate: [
          { required: true, message: "请选择开始时间", trigger: "blur" }
        ],
        nums: [{ required: true, message: "请输入计划产量", trigger: "blur" }]
      },
      formLabelWidth: "120px"
    };
  },
  created() {
    this.Loadpage();
  }
};
</script>