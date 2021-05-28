<template>
  <a-form-model
    ref="ruleForm"
    :model="form"
    :rules="rules"
    :label-col="labelCol"
    :wrapper-col="wrapperCol"
  >
    <a-form-model-item ref="houseArea" label="建筑面积" prop="houseArea">
      <a-input
        v-model="form.houseArea"
        @blur="
          () => {
            $refs.houseArea.onFieldBlur();
          }
        "
      />
    </a-form-model-item>
    <a-form-model-item ref="pric" label="价格" prop="pric">
      <a-input
        v-model="form.pric"
        @blur="
          () => {
            $refs.pric.onFieldBlur();
          }
        "
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
    <a-form-model-item label="户型" prop="houseStyle">
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
    <a-form-model-item :wrapper-col="{ span: 14, offset: 4 }">
      <a-button type="primary" @click="onSubmit">
        查询
      </a-button>
      <a-button style="margin-left: 10px;" @click="resetForm">
        重置
      </a-button>
    </a-form-model-item>
    <!-- <ostable></ostable> -->
    <template>
      <a-table
        :columns="columns"
        :data-source="searchList"
        :pagination="{ pageSize: 5 }"
        :scroll="{ y: 240 }"
        :rowKey="record => record.id"
      />
    </template>
  </a-form-model>
</template>
<script>

export default {
  created(){
      this.$http.get("/getSellMes").then(res=>{ 
         this.searchList = res.data;
      });
  },
  data:()=>(
    {
      labelCol: { span: 4 },
      wrapperCol: { span: 14 },
      // other: '',
      form: {
        houseArea: '',
        pric: "",
        houseType: "",
        houseStyle: "",
        finishCase: "",
      },
      searchList :[],
      rules: {
        
      },
      columns,
  }),
  methods: {
    onSubmit() {
        let obj = this.form;
        if (obj.houseArea == "" && obj.pric == "" && obj.houseType == "" && obj.houseStyle == "" && obj.finishCase == "") {
          this.resetForm();
        }else{
          this.$http.post("/getSellScreenMes",obj).then(res=>{ 
            this.searchList = res.data;
          });
        }
    },
    resetForm() {
      this.$refs.ruleForm.resetFields();
      this.$http.get("/getSellMes").then(res=>{ 
         this.searchList = res.data;
      });
    }
  },
  components:{

  }
};
const columns = [
  {
    title: '客户编号',
    dataIndex: 'id',
    width: 60,
  },
  {
    title: '客户姓名',
    dataIndex: 'name',
    width: 70,
  },
  {
    title: '联系电话',
    dataIndex: 'phone',
    width: 70,
  }, 
  {
    title: '房屋种类',
    dataIndex: 'houseType',
    width: 70,
  }, 
  {
    title: '价格(万元)',
    dataIndex: 'pric',
    width: 70,
  }, 
  {
    title: '户型',
    dataIndex: 'houseStyle',
    width: 70,
  }, 
  {
    title: '建筑面积(㎡)',
    dataIndex: 'houseArea',
    width: 70,
  }, 
  {
    title: '装修情况',
    dataIndex: 'finishCase',
    width: 70,
  }, 
  {
    title: '房屋地址',
    dataIndex: 'address',
    width: 70,
  }, 
  {
    title: '房屋情况',
    dataIndex: 'sale',
    width: 70,
  }
];
</script>
<style scoped>
.ant-input,form .ant-select{
  width: 40% !important;
}
.ant-btn{
  margin-left: 48px !important;
}
.ant-table-tbody > tr > td{
  text-align: center !important;
}
.ant-form-item{
  margin-bottom: 16px !important;
}
</style>