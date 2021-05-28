<template>
  <a-layout id="layout">

    <a-layout-sider class="left-menu" :trigger="null" collapsible>
      <div class="logo">管理信息</div>
      <a-menu theme="dark" mode="inline" :default-selected-keys="['1']">
        <a-sub-menu key="sub1">
          <span slot="title"><span>出租房屋信息管理</span></span>
          <a-menu-item v-for="(item,index) in menuOne" :key="index">
            <router-link :to="item.path">
              {{item.name}}
            </router-link>
          </a-menu-item>
        </a-sub-menu>
        <a-sub-menu key="sub2">
          <span slot="title"><span>出售房屋信息管理</span></span>
          <a-menu-item v-for="(item,index) in menuTwo" :key="'2-'+index">
           <router-link :to="item.path">
              {{item.name}}
            </router-link>
          </a-menu-item>    
        </a-sub-menu>
        <a-sub-menu key="sub3">
          <span slot="title"><span>求租信息管理</span></span>
          <a-menu-item v-for="(item,index) in menuThree" :key="'3-'+index">
          <router-link :to="item.path">
              {{item.name}}
            </router-link>
          </a-menu-item>
        </a-sub-menu>
        <a-sub-menu key="sub4">
          <span slot="title"><span>求购信息管理</span></span>
         <a-menu-item v-for="(item,index) in menuFour" :key="'4-'+index">
           <router-link :to="item.path">
              {{item.name}}
            </router-link>
          </a-menu-item>
        </a-sub-menu>
      </a-menu>
    </a-layout-sider>
    <a-layout>
      <a-layout-header style="background: #fff;display:flex;justify-content: space-between;">
        <span class="header-title">
          <router-link to="/main">
            房屋中介管理系统
          </router-link>
        </span>
        <template>
          <a-avatar icon="user" id="tx"/>
          <a-dropdown>
            <a class="ant-dropdown-link" @click="e => e.preventDefault()">
              {{user}}
              <a-icon type="down" />
            </a>
            <a-menu slot="overlay">
              <a-menu-item>
                <a href="javascript:;" @click="countDown">
                  <a-icon type="edit" />
                  修改密码
                </a>
              </a-menu-item>
              <a-menu-item>
                <a href="javascript:;" @click="logOut">
                  <a-icon type="logout"/>
                    注销登录
                  </a>
              </a-menu-item>
            </a-menu>
          </a-dropdown>
          <a-modal id="modalm" v-model="visible" title="修改密码" ok-text="确认" :ant-click-animating-without-extra-node="visible" :maskClosable="false"
          cancel-text="取消" @ok="submitForm('ruleForm')" @cancel="resetForm('ruleForm')">
            <a-form-model ref="ruleForm" :model="ruleForm" :rules="rules" v-bind="layout">
              <a-form-model-item has-feedback label="账号" prop="number">
                <a-input v-model="ruleForm.number" />
              </a-form-model-item>
              <a-form-model-item has-feedback label="旧密码" prop="oldPass">
                <a-input v-model="ruleForm.oldPass" type="password" autocomplete="off" />
              </a-form-model-item>
              <a-form-model-item has-feedback label="新密码" prop="newPass">
                <a-input v-model="ruleForm.newPass" type="password" autocomplete="off" />
              </a-form-model-item>
              <a-form-model-item :wrapper-col="{ span: 14, offset: 4 }">
                <a-button type="primary" @click="submitForm('ruleForm')">
                  确定
                </a-button>
                <a-button style="margin-left: 10px" @click="resetForm('ruleForm')">
                  重置
                </a-button>
              </a-form-model-item>
            </a-form-model>
          </a-modal>
        </template>
      </a-layout-header>
      <a-layout-content :style="{ margin: '24px 16px', padding: '24px', background: '#fff', minHeight: '280px' }">
        <router-view></router-view>
      </a-layout-content>
    </a-layout>   
  </a-layout>
</template>
<script>
  let checkPending;
  let checkPending1;
  let checkPending2;
  let checkPass = (rule, value, callback) => {
    clearTimeout(checkPending);
    checkPending = setTimeout(() => {
      if (value ==  window.sessionStorage.getItem('userName')) {
        callback();
      } else {
        callback(new Error('请正确输入当前登录账号!'));
      }
    }, 1000);
  };

  let validatePass = (rule, value, callback) => {
    clearTimeout(checkPending1);
    checkPending1 = setTimeout(() => {
      if (value == window.sessionStorage.getItem('userPwd')) {
        callback();
      } else {
        callback(new Error('旧密码输入有误!'));
      }
    }, 1000);
  };

  let reg = new RegExp(/^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,20}$/)
  let validatePass2 = (rule, value, callback) => {
    clearTimeout(checkPending2);
    checkPending2 = setTimeout(() => {
      if (reg.test(value)) {
        callback();
      } else {
        callback(new Error('密码为数字与字母混合并大于6位!'));
      }
    }, 1000);
  };

export default { 
  created(){
    this.user = window.sessionStorage.getItem('user');
    this.userName = window.sessionStorage.getItem('userName');
    this.userPwd = window.sessionStorage.getItem('userPwd');
    console.log(this.user)
    console.log(this.userName)
    console.log(this.userPwd)
  },
  data:()=>({
    ruleForm: {
      newPass: '',
      oldPass: '',
      number: '',
    },
    rules: {
      oldPass: [{ validator: validatePass, trigger: 'change' }],
      newPass: [{ validator: validatePass2, trigger: 'change' }],
      number: [{ validator: checkPass, trigger: 'change' }],
    },
    layout: {
      labelCol: { span: 4 },
      wrapperCol: { span: 14 },
    },
    visible: false,
    menuOne:[
      {
        name:"显示全部信息",
        path:"/oneAllMes",
      },
      {
        name:"查询信息",
        path:"/oneSearchMes"
      },
      {
        name:"插入信息",
        path:"/oneAddMes"
      },
      {
        name:"修改信息",
        path:"/oneChangeMes"
      },
      {
        name:"删除信息",
        path:"/oneDeleteMes"
      },
      {
        name:"合租信息添加",
        path:"/oneAddJr"
      },
      {
        name:"合租信息查询",
        path:"/oneSearchJr"
      },
      {
        name:"合租信息删除",
        path:"/oneDeleteJr"
      }
    ],
    menuTwo:[
      {
        name:"显示全部信息",
        path:"/twoAllMes"
      },
      {
        name:"查询信息",
        path:"/twoSearchMes"
      },
      {
        name:"插入信息",
        path:"/twoAddMes"
      },
      {
        name:"修改信息",
        path:"/twoDeleteMes"
      }
    ],

    menuThree:[
      {
        name:"显示全部信息",
        path:"/threeAllMes"
      },
      {
        name:"记录信息",
        path:"/threeRecordMes"
      },
      {
        name:"删除信息",
        path:"/threeDeleteMes"
      }
    ],

    menuFour:[
      {
        name:"显示全部信息",
        path:"/fourAllMes"
      },
      {
        name:"记录信息",
        path:"/fourRecordMes"
      },
      {
        name:"删除信息",
        path:"/fourChangeMes"
      }
    ],
    user:"",
    userName:"",
    userPwd:""
  }),
  methods:{
    countDown() {
      this.visible = true;
    },
    // 注销账号
    logOut(){
      let $this = this;
      this.$confirm({
        title: '确定注销此账号吗?',
        content: '一旦注销将返回登录界面,谨慎操作!',
        okText: '确定',
        cancelText: '取消',
        onOk() {
          $this.openMessage();
        },
        onCancel() {
          console.log('No');
        },
      });
    },
    openMessage() {
      const key = 'updatable';
      this.$message.loading({ content: '注销中...', key });
      setTimeout(() => {
        this.$message.success({ content: '注销成功!', key, duration: 1 });
        this.$router.push("/");
        window.location.reload();
      }, 2500);
    },
    submitForm(formName) {
      let secondsToGo;
      this.$refs[formName].validate(valid => {
        if (valid) {
          let use = {};
          use.userName = this.ruleForm.number;
          use.userPwd = this.ruleForm.newPass;
          // console.log(use)
          let that = this;
          this.$http.post('/upDataPwd',use).then(res => {

            secondsToGo = 5;
            const modal = this.$success({
              title: '密码修改成功!',
              content: ` 倒计时 ${secondsToGo} 秒后,自动退出登录...`,
              okText:"确定",
              onOk(){
                 that.$router.replace('/');
                 window.location.reload();
              }
            });

            const interval = setInterval(() => {
              secondsToGo -= 1;
              if (secondsToGo <= 0) {
                that.$router.replace('/');
                window.location.reload();
              }
              modal.update({
                content: `倒计时 ${secondsToGo} 秒后,自动退出登录...`,
              });
            }, 1000);

            setTimeout(() => {
              clearInterval(interval);
              modal.destroy();
            }, secondsToGo * 1000);

          })
          this.visible = false;
          this.$refs[formName].resetFields();
        } else {
          // alert('请正确输入修改账号信息!');
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
  }
};
</script>
<style>

/* 设置滚动条的样式 */
::-webkit-scrollbar {
  width:8px;
}
/* 滚动槽 */
::-webkit-scrollbar-track {
-webkit-box-shadow:inset006pxrgba(0,0,0,0.3);
border-radius:10px;
}
/* 滚动条滑块 */
::-webkit-scrollbar-thumb {
border-radius:10px;
background: rgb(97, 97, 97, 0.7);
-webkit-box-shadow:inset006pxrgba(0,0,0,0.5);
}
::-webkit-scrollbar-thumb:window-inactive {
background:rgba(0, 0, 0, 0.4);
}
#rcDialogTitle0{
  text-align: center;
  font-size: 20px;
  font-weight: bold;
}
#layout {
  height: 100vh;
}
#layout .trigger {
  font-size: 18px;
  line-height: 64px;
  padding: 0 24px;
  cursor: pointer;
  transition: color 0.3s;
}

#layout .trigger:hover {
  color: #1890ff;
}
.ant-layout-header{
  height: 60px !important;
  line-height: 60px !important;
  position: relative;
}
#layout .logo {
  height: 28px;
  line-height: 28px;
  text-align: center;
  color: #ffffff;
  font-size: 25px;
  font-weight: bold;
  font-family: 楷体;
  letter-spacing: 10px;
  margin: 16px;
}
.header-title{
  letter-spacing: 5px;
  background: #fff;
  font-size:22px;
  color:rgb(0 61 230);
  font-weight:bold;
}
.left-menu{
  overflow-y: scroll;
}
#tx{
  margin-top: 14px;
  position: absolute;
  right: 125px;
}
#modalm .ant-modal-footer{
  display: none !important;
}
.ant-modal-body .ant-form-item-control{
  text-align: center;
}
.ant-modal-body .ant-btn.ant-btn-primary{
  margin-left: 30px;
}
.ant-modal-body .ant-btn{
  margin-left: 30px !important;
}
.ant-col.ant-col-4.ant-form-item-label{
  margin-left: 30px !important;
}
.ant-form.ant-form-horizontal{
  margin-top: 20px;
}
#modalm .ant-modal{
  top: 200px !important;
}
</style>
