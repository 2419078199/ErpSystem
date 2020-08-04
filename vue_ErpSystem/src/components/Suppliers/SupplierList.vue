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
         <template slot-scope="scope"> 
               <el-button   size="medium"   type="primary"   icon="el-icon-search"   @click="showDetail(scope.row.id)">详情</el-button>
               <el-button  size="medium"  icon="el-icon-edit"  type="primary"  @click="showEdit(scope.row.id)">编辑</el-button>
               <el-button  size="medium"  type="danger"  icon="el-icon-delete"   @click="Readydelete(scope.row.id)">删除</el-button>
         </template>
     </el-table-column>
    </el-table>
</div>
<!--table信息展示-->
</el-card>
<!--卡片-->
<!-- 添加对话框 dialogVisible:控制添加按钮是否出现-->
<el-dialog
  title="添加供应商"
  :visible.sync="dialogVisible"
  width="30%"
  :before-close="handleClose"
   @close="addFromClose">
  <!-- 添加表单 -->
    <el-form :model="addFrom"  :rules="addFromRules" label-width="100px" ref="addFromRef">
  <el-form-item label="供应商名称" prop="name">
     <el-input v-model="addFrom.name"></el-input>
   </el-form-item>
    <el-form-item label="地址" prop="address">
    <el-input v-model="addFrom.address"></el-input>
  </el-form-item>
    <el-form-item label="联系人" prop="linkman">
    <el-input v-model="addFrom.linkman"></el-input>
  </el-form-item>
    <el-form-item label="电话" prop="tel">
    <el-input v-model="addFrom.tel"></el-input>
  </el-form-item>
  </el-form>
   <!-- 添加表单 -->
  <span slot="footer" class="dialog-footer">
    <el-button @click="dialogVisible = false">取 消</el-button>
    <el-button type="primary" @click="addtoEntity()">确 定</el-button>
  </span>
</el-dialog>
<!-- 添加对话框 -->
<!-- 修改对话框-->
<el-dialog
  title="修改供应商"
  :visible.sync="EditdialogVisible"
  width="30%"
   @close="EditFromClose">
  <!-- 修改表单 -->
    <el-form :model="EditFrom"  :rules="EditFromRules" label-width="100px" ref="EditFromRef">
  <el-form-item label="供应商名称" prop="name">
     <el-input v-model="EditFrom.name"></el-input>
   </el-form-item>
    <el-form-item label="地址" prop="address">
    <el-input v-model="EditFrom.address"></el-input>
  </el-form-item>
    <el-form-item label="联系人" prop="linkman">
    <el-input v-model="EditFrom.linkman"></el-input>
  </el-form-item>
    <el-form-item label="电话" prop="tel">
    <el-input v-model="EditFrom.tel"></el-input>
  </el-form-item>
  </el-form>
   <!-- 修改表单 -->
  <span slot="footer" class="dialog-footer">
    <el-button @click="EditdialogVisible = false">取 消</el-button>
    <el-button type="primary" @click="EidttoEntity()">确 定</el-button>
  </span>
</el-dialog>
<!-- 修改对话框 -->
<!-- 详情对话框-->
<el-dialog
  title="供应商详情"
  :visible.sync="DetaildialogVisible"
  width="30%"
   @close="DetailFromClose">
  <!-- 添加表单 -->
    <el-form   label-width="100px">
  <el-form-item label="供应商名称">
     <el-input v-model="DetailFrom.name"></el-input>
   </el-form-item>
    <el-form-item label="地址">
    <el-input v-model="DetailFrom.address"></el-input>
  </el-form-item>
    <el-form-item label="联系人">
    <el-input v-model="DetailFrom.linkman"></el-input>
  </el-form-item>
    <el-form-item label="电话">
    <el-input v-model="DetailFrom.tel"></el-input>
  </el-form-item>
  </el-form>
</el-dialog>
<!-- 详情对话框-->
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
         //控制修改表单显示
        EditdialogVisible:false,
        //控制详情对话框是否显示
        DetaildialogVisible:false,
        // 添加表单信息
        addFrom:{
            "name": "",
            "address": "",
            "linkman": "",
            "tel": "",
            "credit": "五级"
        },
        // 供应商详情信息
        DetailFrom:{},
         // 修改表单信息
        EditFrom:{},
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
        },
        //修改表单验证规则对象
        EditFromRules:{
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
           this.tableData=res.data;
        },
        //点击关闭添加表单
        handleClose(){
          this.dialogVisible = false
        },
        //关闭添加表单重置内容
        addFromClose(){
           this.$refs.addFromRef.resetFields();
        },
        //进行信息的添加
        addtoEntity(){
          //添加表单预验证 验证数据是否都填写了
          this.$refs.addFromRef.validate(async status=>{
            //验证失败返回
            if(!status) return
            //验证成功进行数据添加
           const {data:res} = await this.$axios.post('PuSupplier/CreatePuSupplier',this.addFrom)
          //添加失败
           if(!res.success){
             return this.$message.error("添加失败");
           }
          //添加成功
           return this.$message.success("添加成功");
           //控制显示
           this.dialogVisible = false;
          //重新获取数据
           this.getSuppliersList()
          })
        },
        //弹出修改对话框
           async showEdit(id){
            //显示修改对话框
            this.EditdialogVisible=true;
            //获取对应供应商信息
           const {data:res} = await this.$axios.get('PuSupplier/PuSupplierById/'+id)
            //修改失败
           if(!res.success){
             return this.$message.error("请求失败");
           }
          //修改成功 将数据渲染到修改对话框
          this.EditFrom=res.data;
        },
        // 修改信息预验证   进行信息修改
        EidttoEntity(){
         this.$refs.EditFromRef.validate(async status=>{
           if(!status) return
           //成功时进行表单提交
           const {data:res} =await this.$axios.put('PuSupplier/EditPuSupplier',this.EditFrom)
           //判断修改结果
           // 失败时
           if(!res.success){
             //返回失败提示
             this.$message.error("修改失败")
           }
           //成功时  //成功失败提示
           this.$message.success("修改成功")
             //隐藏修改框
          this.EditdialogVisible=false;
          //刷新 //重新获取数据
          this.getSuppliersList()
         })
        },
        //关闭修改对话框重置
        EditFromClose(){
            this.EditdialogVisible=false;
        },
        //删除
       async Readydelete(id){
         //弹出删除提示 
        const  status=await this.$confirm('此操作将永久删除该文件, 是否继续?', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        }).catch((err) =>err)//取消取消报错提示catch((err)
        //判断是否删除  confirm=>确定删除  cancel=>取消删除
        if(status=='confirm'){
          //进行删除操作  使用delete提交方式进行删除
         const {data:res} =await this.$axios.delete(`PuSupplier/Delete/${id}`)
         //删除失败
          if(!res.success){//失败就提示权限不足 并且抛出
             return this.$message.error("权限不足");
           }
         //删除成功 提示删除成功
          this.$message.success("删除成功");
          //刷新 //重新获取数据
           this.getSuppliersList()
        }
        },
        //点击详情按钮获取经销商详情
         async  showDetail(id){
          //1.显示详情对话框
          this.DetaildialogVisible=true;
          //2.根据id发起请求获取详情
         const {data:res} =await this.$axios.get(`PuSupplier/PuSupplierById/${id}`)
          //3.将数据填充到DetailFrom
          this.DetailFrom=res.data;
          console.log(DetailFrom)
        },
        //点击关闭详情对话框
        DetailFromClose(){
           this.DetaildialogVisible=false;
        }

    },
    created(){
       this.getSuppliersList();
    }
  }
</script>


