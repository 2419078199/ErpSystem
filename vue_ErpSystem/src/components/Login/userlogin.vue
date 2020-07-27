<template>
  <div class="login_container">
    <div class="login_box">
      <div class="avatar_box">
        <!-- <img src="../assets/infants.jpg" alt="" /> -->
      </div>
      <el-form
        :model="loginForm"
        :rules="loginFromRules"
        label-width="70px"
        ref="loginForm"
        class="login_form"
      >
        <el-form-item prop="account" label="账号">
          <el-input
            v-model="loginForm.account"
            prefix-icon="el-icon-user"
          ></el-input>
        </el-form-item>
        <!-- 密码 -->
        <el-form-item prop="pwd" label="密码">
          <el-input
            v-model="loginForm.pwd"
            prefix-icon="el-icon-lock"
            show-password
          ></el-input>
        </el-form-item>
        <!-- 按钮 -->
        <el-form-item class="btns">
          <el-button
            type="primary"
            @click="loginFormSubmit"
            @keydown.enter="loginFormSubmit()"
            >登录</el-button
          >
          <el-button type="info" @click="loginFormReset">重置</el-button>
        </el-form-item>
      </el-form>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      //登录表单所绑定的数据
      loginForm: {
        account: '',
        pwd: ''
      },
      //登录表单的校验规则
      loginFromRules: {
        account: [
          { required: true, message: '请输入账号', trigger: 'blur' },
          { min: 3, max: 15, message: '长度在 3 到 15 个字符', trigger: 'blur' }
        ],
        pwd: [
          { required: true, message: '请输入密码', trigger: 'blur' },
          { min: 3, max: 15, message: '长度在 3 到 15 个字符', trigger: 'blur' }
        ]
      }
    }
  },
  methods: {
    loginFormReset() {
      //重置登录表单
      this.$refs.loginForm.resetFields()
    },
    loginFormSubmit() {
      //提交登录表单
      this.$refs.loginForm.validate(async (valid) => {
        if (!valid) {
          return this.$message.error('请输入用户名或密码')
        }
        this.loginForm.cId = window.sessionStorage.getItem('cId')
        const { data: res } = await this.$axios.post(
          'Login/Login',
          this.loginForm
        )
        if (!res.success) {
          return this.$message.error(res.msg)
        }
        this.$message.success('登录成功！！！')
        window.sessionStorage.setItem('token', res.data)
        this.$router.push('/home')
      })
    }
  },
  created() {}
}
</script>
<style>
</style>
