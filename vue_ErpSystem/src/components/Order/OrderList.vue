<template>
  <div>
    <!-- 顶部面包屑 -->
    <el-breadcrumb separator="/">
      <el-breadcrumb-item :to="{ path: '/' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>销售管理</el-breadcrumb-item>
      <el-breadcrumb-item>销售列表</el-breadcrumb-item>
    </el-breadcrumb>
    <!-- 卡片区域 -->
    <el-card>
      <!-- 查询添加区域 -->
      <el-row :gutter="20">
        <el-col :span="8">
          <el-input
            placeholder="请输入客户名称"
            v-model="queryInfo.customerName"
            class="input-with-select"
            clearable
            @clear="clearInput"
          >
            <el-button
              slot="append"
              icon="el-icon-search"
              @click="btnSearch"
            ></el-button>
          </el-input>
        </el-col>
        <el-col :span="6">
          <el-button type="primary" @click="addDialogVisible = true"
            >添加订单</el-button
          >
        </el-col>
      </el-row>
      <!-- 表格查询区域 -->
      <el-table :data="orderList" border stripe>
        <el-table-column label="#" type="index"></el-table-column>
        <el-table-column label="订单号" prop="no" width="150"></el-table-column>
        <el-table-column label="用户名" prop="customerName"></el-table-column>
        <el-table-column label="产品名" prop="productName"></el-table-column>
        <el-table-column label="数量" prop="nums"></el-table-column>
        <el-table-column label="单价" prop="price"></el-table-column>
        <el-table-column label="交货时间" prop="deliveryDate">
          <template v-slot="scope">
            {{ scope.row.deliveryDate | dateFormat }}
          </template>
        </el-table-column>
        <el-table-column label="交货方式" prop="deliveryWay"></el-table-column>
        <el-table-column label="订单金额" prop="orderAmount"></el-table-column>
        <el-table-column label="订单状态" prop="status">
          <template v-slot="scope">
            <el-switch
              v-model="scope.row.status"
              active-color="#13ce66"
              inactive-color="#ff4949"
              disabled
            >
            </el-switch>
          </template>
        </el-table-column>
        <el-table-column label="备注" prop="remark"></el-table-column>
        <el-table-column label="操作" fixed="right" width="200">
          <template v-slot="scope">
            <el-button
              size="mini"
              type="primary"
              icon="el-icon-edit"
              @click="showEditDialog(scope.row)"
              >编辑</el-button
            >
            <el-button
              size="mini"
              type="danger"
              icon="el-icon-delete"
              @click="deleteOrder(scope.row)"
              >删除</el-button
            >
          </template>
        </el-table-column>
      </el-table>
    </el-card>
    <!-- 添加对话框 -->
    <el-dialog title="添加订单" :visible.sync="addDialogVisible" width="50%">
      <!-- 对话框主体 -->
      <el-form ref="addFormRef" :model="addForm" label-width="80px">
        <el-form-item label="用户编号">
          <el-select v-model="addForm.customerId" placeholder="请选择用户">
            <el-option
              v-for="item in customerList"
              :key="item.id"
              :label="item.name"
              :value="item.id"
            >
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="产品编号">
          <el-select v-model="addForm.productId" placeholder="请选择用户">
            <el-option
              v-for="item in productList"
              :key="item.id"
              :label="item.name"
              :value="item.id"
            >
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="数量">
          <el-input v-model="addForm.nums"></el-input>
        </el-form-item>
        <el-form-item label="单价">
          <el-input v-model="addForm.price"></el-input>
        </el-form-item>
        <el-form-item label="交货方式">
          <el-input v-model="addForm.deliveryWay"></el-input>
        </el-form-item>
        <el-form-item label="备注">
          <el-input v-model="addForm.remark"></el-input>
        </el-form-item>
      </el-form>
      <!-- 对话框底部 -->
      <span slot="footer" class="dialog-footer">
        <el-button @click="addDialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="addFromSubmit">确 定</el-button>
      </span>
    </el-dialog>
    <!-- 编辑对话框 -->
    <el-dialog title="编辑订单" :visible.sync="editDialogVisible" width="50%">
      <!-- 对话框主体 -->
      <el-form ref="editFormRef" :model="editForm" label-width="80px">
        <el-form-item label="用户编号">
          <el-select v-model="editForm.customerId" placeholder="请选择用户">
            <el-option
              v-for="item in customerList"
              :key="item.id"
              :label="item.name"
              :value="item.id"
            >
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="产品编号">
          <el-select v-model="editForm.productId" placeholder="请选择用户">
            <el-option
              v-for="item in productList"
              :key="item.id"
              :label="item.name"
              :value="item.id"
            >
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="数量">
          <el-input v-model="editForm.nums"></el-input>
        </el-form-item>
        <el-form-item label="单价">
          <el-input v-model="editForm.price"></el-input>
        </el-form-item>
        <el-form-item label="交货方式">
          <el-input v-model="editForm.deliveryWay"></el-input>
        </el-form-item>
        <el-form-item label="备注">
          <el-input v-model="editForm.remark"></el-input>
        </el-form-item>
      </el-form>
      <!-- 对话框底部 -->
      <span slot="footer" class="dialog-footer">
        <el-button @click="editDialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="editFromSubmit">确 定</el-button>
      </span>
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
    >
    </el-pagination>
  </div>
</template>

<script>
export default {
  data() {
    return {
      queryInfo: {
        pageSize: 5,
        pageNum: 1,
        customerName: ''
      },
      totalCount: 0,
      orderList: [],
      productList: [],
      customerList: [],
      addForm: {
        no: 'asdasd',
        customerId: '',
        productId: '',
        nums: 0,
        price: 0,
        deliveryDate: '',
        deliveryWay: '',
        orderDate: '',
        orderAmount: 0,
        handleId: 0,
        operatorId: 0,
        // operatorTime: 0,
        status: 0,
        remark: ''
      },
      editForm: {},
      addDialogVisible: false,
      editDialogVisible: false
    }
  },
  methods: {
    //获取订单列表信息
    async getOrderList() {
      const res = await this.$axios.get('SlOrder/GetOrders', {
        params: this.queryInfo
      })
      const pagination = JSON.parse(res.headers['x-pagination'])
      this.totalCount = pagination.totalCount
      this.orderList = res.data.data
    },
    //获取产品列表信息
    async GetProductList() {
      const res = await this.$axios.get('PrProduct/GetPrProducts')
      this.productList = res.data.data
    },
    //获取用户列表信息
    async GetCustomertList() {
      const { data: res } = await this.$axios.get('SlCustomer/GetCustomer')
      this.customerList = res.data
    },
    //搜索订单
    btnSearch() {
      this.getOrderList()
    },
    //清空搜索
    clearInput() {
      this.getOrderList()
    },
    //删除订单
    async deleteOrder(row) {
      const result = await this.$confirm(
        '此操作将永久删除该订单, 是否继续?',
        '提示',
        {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        }
      ).catch((err) => err)
      if (result != 'confirm') {
        return this.$message.info('取消了删除操作')
      }
      const { data: res } = await this.$axios.delete(
        `SlOrder/DeleteOrder/${row.id}`
      )
      if (!res.success) {
        return this.$message.erroe('删除异常，请稍后重试！')
      }
      this.$message.success('删除成功！')
      this.getOrderList()
    },
    //提交表单
    async addFromSubmit() {
      const { data: res } = await this.$axios.post(
        'SlOrder/AddOrder',
        this.addForm
      )
      console.log(res)
      if (!res.success) {
        return this.$message.error('添加异常,请联系管理员')
      }
      this.$message.success('添加成功')
      this.getOrderList()
      this.addDialogVisible = false
    },
    //展示编辑对话框
    async showEditDialog(row) {
      const { data: res } = await this.$axios.get(
        `SlOrder/GetOrderById/${row.id}`
      )
      this.editForm = res.data
      this.editDialogVisible = true
    },
    //提交编辑信息
    async editFromSubmit() {
      const { data: res } = await this.$axios.put(
        'SlOrder/EditOrder',
        this.editForm
      )
      if (!res.success) {
        return this.$message.error('编辑异常，请联系管理员')
      }
      this.$message.success('编辑成功')
      this.getOrderList()
      this.editDialogVisible = false
    },
    //改变当前页
    handleCurrentChange(newNum) {
      this.queryInfo.pageNum = newNum
      this.getOrderList()
    },
    //改变Size
    handleSizeChange(newSize) {
      this.queryInfo.pageSize = newSize
      this.getOrderList()
    }
  },
  created() {
    this.getOrderList()
    this.GetProductList()
    this.GetCustomertList()
  }
}
</script>
