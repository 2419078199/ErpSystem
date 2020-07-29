<template>
  <div>
    <el-row :gutter="20">
      <el-col :span="6">
        <el-input placeholder="请输入内容" v-model="serchno" class="input-with-select">
          <el-button slot="append" icon="el-icon-search"></el-button>
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
      <el-table-column prop="productDate" label="生产时间" width="300">
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
      <el-form :model="addPlan">
        <el-form-item label="订单号" :label-width="formLabelWidth">
          <el-select v-model="addPlan.No" filterable placeholder="请选择">
            <el-option v-for="item in Orderno" :key="item.id" :label="item.no" :value="item.no"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="产品编号" :label-width="formLabelWidth">
          <el-input v-model="addPlan.ProductId" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item label="计划产量" :label-width="formLabelWidth">
          <el-input v-model="addPlan.Nums" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item label="计划开始时间" :label-width="formLabelWidth">
          <el-date-picker v-model="addPlan.ProductDate" type="datetime" placeholder="选择日期时间"></el-date-picker>
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
      <el-form :model="EditPlan">
        <el-form-item label="计划产量" :label-width="formLabelWidth">
          <el-input v-model="EditPlan.nums" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item label="计划开始时间" :label-width="formLabelWidth">
          <el-date-picker v-model="EditPlan.productDate" type="datetime" placeholder="选择日期时间"></el-date-picker>
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
  </div>
</template>

<script>
export default {
  methods: {
    Edit(index, data) {
      this.EditProductPlan = true;
       this.$axios
        .get("PrProductTask/GetPrProductTasksById/"+data[index].id)
        .then(response => (this.EditPlan = response.data.data))
        .catch(function(error) {
          // 请求失败处理
          console.log(error);
        });
    },
    Editdialog(){
       this.$axios
        .put("PrProductTask/EditPrProductTask",this.EditPlan)
        .then(response => (this.$message.success('修改成功！'),
        this.EditProductPlan = false,
        this.Loadpage()
        ))
        .catch(function(error) {
          // 请求失败处理
          this.$message.success('修改失败！'),
          this.EditProductPlan = false
        });
    },
    Loadpage() {
      this.$axios
        .get("PrProductTask/GetPrProductTasks")
        .then(response => (this.tableData = response.data.data))
        .catch(function(error) {
          // 请求失败处理
          console.log(error);
        });
    },
    delPlan(index, data) {
      if (confirm("确认要删除该计划吗？")) {
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
      }
    },
    add() {
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
    }
  },
  watch: {
    "addPlan.No"(newval, oldval) {
      this.$axios
        .get("SlOrder/GetOrderById/" + newval)
        .then(
          response => (this.addPlan.ProductId = response.data.data.productId)
        )
        .catch(function(error) {
          // 请求失败处理
          console.log(error);
        });
    },
    AddProductPlan(newval, oldval) {
      if (newval == true) {
        this.$axios
          .get("SlOrder/GetOrders")
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
      tableData: [],
      AddProductPlan: false,
      EditProductPlan: false,
      Orderid: "",
      Orderno: [],
      serchno: "",
      addPlan: {
        No: "",
        ProductId: null,
        ProductDate: "",
        Nums: 0,
        Remark: ""
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
        operateTime:"",
        status:"",
        remark: ""
      },
      formLabelWidth: "120px"
    };
  },
  created() {
    this.Loadpage();
  }
};
</script>