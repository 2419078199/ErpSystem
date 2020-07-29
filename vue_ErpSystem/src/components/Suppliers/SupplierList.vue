<template>
<div>
    <!-- <div>
    <el-breadcrumb separator="/">
  <el-breadcrumb-item :to="{ path: '/' }">首页</el-breadcrumb-item>
  <el-breadcrumb-item><a href="/">添加供应商</a></el-breadcrumb-item>
  <el-breadcrumb-item>活动列表</el-breadcrumb-item>
  <el-breadcrumb-item>活动详情</el-breadcrumb-item>
</el-breadcrumb>
</div> -->
<!--输入框-->
<el-card class="box-card">
<div>
    <el-row :gutter="25">
      <el-col :span="8">
          <div>
           <el-input placeholder="请输入内容">
             <el-button slot="append" icon="el-icon-search"></el-button>
           </el-input>
        </div>
</el-col>
      <el-col :span="4"><el-button type="primary"  @click="dialogVisible = true">添加供应商</el-button></el-col>
    
    </el-row>
</div>
<!--输入框-->
<!--table信息展示-->
<div>
    <el-table :data="tableData"  stripe  style="width: 100%">
      <el-table-column type="index" label="序号"></el-table-column>
      <el-table-column  prop="name"  label="供应商名" width="200"> </el-table-column>  
      <el-table-column  prop="address"  label="地址"  width="200">  </el-table-column>
      <el-table-column  prop="linkman"   label="联系人"   width="200"> </el-table-column>
      <el-table-column   prop="tel"  label="电话"   width="200">  </el-table-column>
      <el-table-column   prop="credit"   label="信誉度"  width="400">  </el-table-column>
      <el-table-column label="操作"> 
         <template slot-scope="scope">  <el-button   size="medium"   type="primary"   icon="el-icon-search"   @click="handleEdit(scope.$index, scope.row)">详情</el-button>
           <el-button  size="medium"  icon="el-icon-edit"  type="primary"  @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
           <el-button  size="medium"  type="danger"  icon="el-icon-delete"   @click="handleDelete(scope.$index, scope.row)">删除</el-button>
         </template>
     </el-table-column>
    </el-table>
</div>
<!--table信息展示-->
</el-card>
<!--卡片-->
<!-- 添加 -->
<el-dialog
  title="添加供应商"
  :visible.sync="dialogVisible"
  width="30%"
  :before-close="handleClose">
  <!-- 添加表单 -->
    <el-form :model="addFrom"  :rules="addFromRules" label-width="100px" ref="addFromRef" >
  <el-form-item label="供应商名称" prop="name"> 
     <el-input v-model="addFrom.name"></el-input> 
   </el-form-item>
    <el-form-item label="地址" prop="address">
    <el-input v-model="addFrom.name"></el-input>
  </el-form-item>
    <el-form-item label="联系人" prop="linkman">
    <el-input v-model="addFrom.name"></el-input>
  </el-form-item>
    <el-form-item label="电话" prop="tel">
    <el-input v-model="addFrom.name"></el-input>
  </el-form-item>
  </el-form>
   <!-- 添加表单 -->
  <span slot="footer" class="dialog-footer">
    <el-button @click="dialogVisible = false">取 消</el-button>
    <el-button type="primary" @click="dialogVisible = false">确 定</el-button>
  </span>
</el-dialog>
<!-- 添加 -->
</div>
</template>

<script>
  export default {
    data() {
      return {
        //供应商信息List
        tableData: [],
        //控制添加表单显示
        dialogVisible:false,
        // 添加表单信息
        addFrom:{
            "name": "",
            "address": "",
            "linkman": "",
            "tel": "",
            "credit": "五级"
        },
        //添加表单验证规则对象
        addFromRules:{
          name:[
           { required: true, message: '请输入供应商名称', trigger: 'blur' }
          ],
          address:[
            {required: true, message: '请输入地址', trigger: 'blur' }
          ],
           linkman:[
            {required: true, message: '请输入联系人', trigger: 'blur' }
          ],
           tel:[
            {required: true, message: '请输入电话', trigger: 'blur' }
          ]
        }
      }
    },
    methods:{
       async getSuppliersList(){
           const {data:res}=await this.$axios.get('PuSupplier/PuSupplier');
           console.log(res.data);
           this.tableData=res.data;
        },
        //关闭添加表单
        handleClose(){
          this.dialogVisible = false
        }
    },
    created(){
       this.getSuppliersList(); 
    }
  }
</script>