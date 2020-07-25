<template>
  <div class="wrapper">
    <!-- 头部信息 -->
    <v-head></v-head>
    <!-- 左部菜单栏 -->
    <v-sidebar></v-sidebar>
    <!-- 主体区域 -->
    <div class="content-box" :class="{ 'content-collapse': collapse }">
      <v-tags></v-tags>
      <div class="content">
        <transition name="move" mode="out-in">
          <keep-alive :include="tagsList">
            <!-- 核心视图区域 -->
            <router-view></router-view>
          </keep-alive>
        </transition>
        <el-backtop target=".content"></el-backtop>
      </div>
    </div>
  </div>
</template>

<script>
import bus from './bus'
import vHead from './Header'
import vSidebar from './Sidebar.vue'
import vTags from './Tags.vue'
export default {
  data() {
    return {
      tagsList: [],
      collapse: false
    }
  },
  components: {
    vHead,
    vSidebar,
    vTags
  },
  created() {
    bus.$on('collapse-content', (msg) => {
      this.collapse = msg
    })
    // 只有在标签页列表里的页面才使用keep-alive，即关闭标签之后就不保存到内存中了。12
    bus.$on('tags', (msg) => {
      let arr = []
      for (let i = 0, len = msg.length; i < len; i++) {
        msg[i].name && arr.push(msg[i].name)
      }
      this.tagsList = arr
    })
  }
}
</script>
