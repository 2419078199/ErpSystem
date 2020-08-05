<template>
  <div>
    <!-- 顶部面包屑 -->
    <el-breadcrumb separator="/">
      <el-breadcrumb-item :to="{ path: '/' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>基本信心</el-breadcrumb-item>
      <el-breadcrumb-item>客户信息</el-breadcrumb-item>
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
      <!-- 表格显示区域 -->
      <el-table :data="customerList" border stripe>
        <el-table-column label="#" type="index"></el-table-column>
        <el-table-column label="姓名" prop="name"> </el-table-column>
        <el-table-column label="地址" prop="address"> </el-table-column>
        <el-table-column label="电话" prop="custtel"> </el-table-column>
        <el-table-column label="邮箱" prop="email"> </el-table-column>
        <el-table-column label="生日" prop="birthday">
          <template v-slot="scope">
            {{ scope.row.birthday | dateFormat }}
          </template>
        </el-table-column>
        <el-table-column label="操作">
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
              @click="deleteCustomer(scope.row)"
              >删除</el-button
            >
          </template>
        </el-table-column>
      </el-table>
    </el-card>
    <!-- 添加对话框 -->
    <el-dialog title="提示" :visible.sync="addDialogVisible" width="50%">
      <!-- 对话框主体 -->
      <el-form ref="addFormRef" :model="addForm" label-width="80px">
        <el-form-item label="姓名">
          <el-input v-model="addForm.name"></el-input>
        </el-form-item>
        <el-form-item label="地址">
          <el-input v-model="addForm.address"></el-input>
        </el-form-item>
        <el-form-item label="电话">
          <el-input v-model="addForm.linktel"></el-input>
        </el-form-item>
        <el-form-item label="邮箱">
          <el-input v-model="addForm.email"></el-input>
        </el-form-item>
        <el-form-item label="生日">
          <el-date-picker
            v-model="addForm.birthday"
            type="date"
            format="yyyy-MM-dd"
            placeholder="选择日期"
          >
          </el-date-picker>
        </el-form-item>
      </el-form>
      <!-- 对话框底部 -->
      <span slot="footer" class="dialog-footer">
        <el-button @click="addDialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="addFromSubmit">确 定</el-button>
      </span>
    </el-dialog>
    <!-- 编辑对话框 -->
    <el-dialog title="提示" :visible.sync="editDialogVisible" width="50%">
      <!-- 对话框主体 -->
      <el-form ref="editFormRef" :model="editForm" label-width="80px">
        <el-form-item label="姓名">
          <el-input v-model="editForm.name"></el-input>
        </el-form-item>
        <el-form-item label="地址">
          <el-input v-model="editForm.address"></el-input>
        </el-form-item>
        <el-form-item label="电话">
          <el-input v-model="editForm.linktel"></el-input>
        </el-form-item>
        <el-form-item label="邮箱">
          <el-input v-model="editForm.email"></el-input>
        </el-form-item>
        <el-form-item label="生日">
          <el-date-picker
            v-model="editForm.birthday"
            type="date"
            format="yyyy-MM-dd"
            placeholder="选择日期"
          >
          </el-date-picker>
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
      addForm: {
        name: '',
        address: '',
        linktel: '',
        email: '',
        birthday: ''
      },
      editForm: {},
      totalCount: 0,
      customerList: [],
      addDialogVisible: false,
      editDialogVisible: false
    }
  },
  methods: {
    async getCustomerList() {
      const res = await this.$axios.get('SlCustomer/GetCustomer', {
        params: this.queryInfo
      })
      this.customerList = res.data.data
      const pagination = JSON.parse(res.headers['x-pagination'])
      this.totalCount = pagination.totalCount
    },
    //根据客户名搜索
    btnSearch() {
      this.getCustomerList()
    },
    //清空搜索条件
    clearInput() {
      this.getCustomerList()
    },
    // 改变Size
    handleSizeChange(newSize) {
      this.queryInfo.pageSize = newSize
      this.getCustomerList()
    },
    //改变页码
    handleCurrentChange(newNum) {
      this.queryInfo.pageNum = newNum
      this.getCustomerList()
    },
    //显示编辑对话框
    async showEditDialog(row) {
      const { data: res } = await this.$axios.get(
        'SlCustomer/GetCustomerById/' + row.id
      )
      this.editForm = res.data
      this.editDialogVisible = true
    },
    //删除客户
    deleteCustomer() {},
    //添加
    async addFromSubmit() {
      const { data: res } = await this.$axios.post(
        'SlCustomer/AddCustomer',
        this.addForm
      )
      if (!res.success) {
        return this.$message.error('添加异常，请联系管理员')
      }
      this.$message.success('添加成功！！！')
      this.getCustomerList()
      this.addDialogVisible = false
    },
    //添加编辑
    async editFromSubmit() {
      const { data: res } = await this.$axios.put(
        'SlCustomer/EditCustomer',
        this.editForm
      )
      if (!res.success) {
        return this.$message.error('编辑异常，请联系管理员')
      }
      this.$message.success('编辑成功！！！')
      this.getCustomerList()
      this.editDialogVisible = false
    }
  },
  created() {
    this.getCustomerList()
  }
}
</script>
