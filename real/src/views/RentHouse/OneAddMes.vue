<template>
   <a-form-model
    ref="ruleForm"
    :model="form"
    :rules="rules"
    :label-col="labelCol"
    :wrapper-col="wrapperCol"
  >
      
    <a-form-model-item ref="name" label="客户姓名" prop="name">
      <a-input
        v-model="form.name"
      />
    </a-form-model-item>
    <a-form-model-item ref="phone" label="联系电话" prop="phone">
      <a-input
        v-model="form.phone"
      />
    </a-form-model-item>
    <a-form-model-item ref="houseArea" label="建筑面积" prop="houseArea">
      <a-input
        v-model="form.houseArea"
      />
    </a-form-model-item>
    <a-form-model-item ref="monthMoney" label="房屋月租" prop="monthMoney">
      <a-input
        v-model="form.monthMoney"
      />
    </a-form-model-item>
    <a-form-model-item label="房屋种类" prop="houseType">
      <a-select v-model="form.houseType">
        <a-select-option value="平房">
          平房
        </a-select-option>
        <a-select-option value="楼房">
          楼房
        </a-select-option>
        <a-select-option value="其他">
          其他
        </a-select-option>
      </a-select>
    </a-form-model-item>
    <a-form-model-item label="房屋户型" prop="houseStyle">
      <a-select v-model="form.houseStyle">
        <a-select-option value="单间">
          单间
        </a-select-option>
        <a-select-option value="一室一厅">
          一室一厅
        </a-select-option>
        <a-select-option value="三室一厅">
          三室一厅
        </a-select-option>
        <a-select-option value="独门独院">
          独门独院
        </a-select-option>
      </a-select>
    </a-form-model-item>
    <a-form-model-item label="装修情况" prop="finishCase">
      <a-select v-model="form.finishCase">
        <a-select-option value="未装修">
          未装修
        </a-select-option>
        <a-select-option value="简单装修">
          简单装修
        </a-select-option>
        <a-select-option value="中档装修">
          中档装修
        </a-select-option>
        <a-select-option value="高档装修">
          高档装修
        </a-select-option>
      </a-select>
    </a-form-model-item>
    <a-form-model-item label="出租情况" prop="rentOut">
      <a-select v-model="form.rentOut">
        <a-select-option value="已出租">
          已出租
        </a-select-option>
        <a-select-option value="未出租">
          未出租
        </a-select-option>
      </a-select>
    </a-form-model-item>
        <a-form-model-item ref="address" label="房屋地址" prop="address">
      <a-input id="address"
        v-model="form.address"
      />
    </a-form-model-item>
    <a-form-model-item :wrapper-col="{ span: 14, offset: 4 }">
      <a-button type="primary" @click="onSubmit">
        确定
      </a-button>
      <a-button style="margin-left: 10px;" @click="resetForm">
        重置
      </a-button>
    </a-form-model-item>
  </a-form-model>
</template>
<script>

export default {
  data:()=>({
      labelCol: { span: 4 },
      wrapperCol: { span: 14 },
      // other: '',
      form: {
        name:"",
        houseArea: '',
        phone: "",
        monthMoney: "",
        houseType: "",
        houseStyle: "",
        finishCase: "",
        address:"",
        rentOut:""
      },
      rules: {
        name: [{ required: true, message: '请输入姓名!',trigger:"onsubmit"}],
        monthMoney: [{ required: true, message: '请输入正确的房屋月租!',pattern: new RegExp(/^[1-9]\d*$/, "g"),trigger:"onsubmit"}],
        houseArea: [{ required: true, message: '请输入正确的房屋面积!',pattern: new RegExp(/^[1-9]\d*$/, "g"),trigger:"onsubmit"}],
        houseType: [{ required: true, message: '请选择房屋种类!',trigger:["onsubmit",'change']}],
        houseStyle: [{ required: true,message: '请选择房屋户型!',trigger:["onsubmit",'change']}],
        finishCase: [{ required: true, message: '请选择装修情况!',trigger:["onsubmit",'change']}],
        phone: [{ required: true, message: '请输入正确的手机号!',pattern: /^1[3|4|5|7|8][0-9]\d{8}$/,trigger:"onsubmit"}],
        address: [{ required: true, message: '请输入房屋地址!',trigger:"onsubmit"}],
        rentOut: [{ required: true, message: '请选择出租情况!',trigger:["onsubmit",'change']}],
      },
  }),
  methods:{
    onSubmit() {
        this.$refs.ruleForm.validate(valid => {
          if (valid) {
            let obj = this.form;
            this.$http.post("/AddItemMes",obj).then(res=>{
              console.log(res);
            })
            alert('添加成功!');
            this.$refs.ruleForm.resetFields();
          } else {
            return false;
          }
        });
    },
    resetForm() {
      this.$refs.ruleForm.resetFields();
    }
  },
  components:{

  }
}
</script>
<style scoped>
.ant-input{
  width: 30%;
}
form .ant-select{
  width: 40%;
}
.ant-btn{
  margin-left: 48px !important;
}
.ant-table-tbody > tr > td{
  text-align: center !important;
}
/* .ant-form-item{
  margin-bottom: 14px !important;
}         */
#address{
  width: 60% !important;
}        
                                           
</style>