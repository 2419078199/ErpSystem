<template>
  <div class="sidebar">
   <el-menu
      class="sidebar-el-menu"
      :default-active="onRoutes"
      :collapse="collapse"
      background-color="#324157"
      text-color="#bfcbd9"
      active-text-color="#20a0ff"
      unique-opened
      router
    >
     <el-menu-item index="/welcome">
        <i class="el-icon-s-home"></i>
        <span slot="title">主页</span>
      </el-menu-item>
      <el-submenu
        :index="FirstMenu.url"
        v-for="FirstMenu in items"
        :key="FirstMenu.id"
      >
        <template slot="title">
          <i :class="FirstMenu.icon"></i>
          <span>{{ FirstMenu.name }}</span>
        </template>
        <el-menu-item
          :index="SecondMenus.url"
          v-for="SecondMenus in FirstMenu.secondMenus"
          :key="SecondMenus.id"
        >
          <i :class="SecondMenus.icon"></i>{{ SecondMenus.name }}</el-menu-item
        >
      </el-submenu>
    </el-menu>
  </div>
</template>

<script>
import bus from './bus'
export default {
  data() {
    return {
      collapse: false,
      items: []
    }
  },
  computed: {
    onRoutes() {
      return this.$route.path.replace('/', '')
    }
  },
  created() {
    // 通过 Event Bus 进行组件间通信，来折叠侧边栏
    bus.$on('collapse', (msg) => {
      this.collapse = msg
      bus.$emit('collapse-content', msg)
    });
   this.$axios
      .get('Power/GetMenus')
      .then(response => (
        this.items =response.data.data
      ))
      .catch(function (error) { // 请求失败处理
        console.log(error);
      });
  }
}
</script>

<style scoped>
.sidebar {
  display: block;
  position: absolute;
  left: 0;
  top: 70px;
  bottom: 0;
  overflow-y: scroll;
}
.sidebar::-webkit-scrollbar {
  width: 0;
}
.sidebar-el-menu:not(.el-menu--collapse) {
  width: 250px;
}
.sidebar > ul {
  height: 100%;
}

</style>
