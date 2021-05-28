<template>
  <div>
    <div style="margin-bottom: 16px">
      <a-button type="primary" :disabled="!hasSelected"  @click="showDeleteConfirm">
        删除
      </a-button>
      <span style="margin-left: 8px">
        <template v-if="hasSelected">
          {{ `已选择 ${selectedRowKeys.length} 个` }}
        </template>
      </span>
    </div>
    <a-table
      :row-selection="{ selectedRowKeys: selectedRowKeys, onChange: onSelectChange }"
      :columns="columns"
      :data-source="data"
      :pagination="{ pageSize: 12}"
      :rowKey="record => record.id"
    />
  </div>
</template>
<script>
import qs from "qs"
import Vue from "vue"
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
    title: '户型',
    dataIndex: 'houseStyle',
    width: 70,
  }, 
  {
    title: '面积(㎡)',
    dataIndex: 'houseArea',
    width: 70,
  }, 
  {
    title: '装修情况',
    dataIndex: 'finishCase',
    width: 70,
  },
];

export default {
  created(){
    this.$http.get("/getBegRentMes").then(res=>{ 
        this.data = res.data;
    });
  },
  data() {
    return {
      data:[],
      columns,
      selectedRowKeys: [], // Check here to configure the default column
    };
  },
  computed: {
    hasSelected() {
      return this.selectedRowKeys.length > 0;
    },
  },
  methods: {
    showDeleteConfirm() {
      let deleteMenu = this.selectedRowKeys;
      let that = this;
      this.$confirm({
        title: '确定删除房客信息吗?',
        content: '谨慎选择',
        okText: '确定',
        okType: 'danger',
        cancelText: '取消',
        onOk() {
          console.log('OK');
          that.$http.post('/DeleteBegItemMes',deleteMenu).then(res => {
          }).catch(() => {
            console.log('请求失败')
          })
          that.getList();
        },
        onCancel() {
          console.log('No');
        },
      });
    },
    getList(){
      for (let index = 0; index < this.selectedRowKeys.length; index++) {
        let deleteIndex = this.data.findIndex(item => item.id === this.selectedRowKeys[index]);
        this.data.splice(deleteIndex,1);
      }
      // this.$http.post("/getRentMes").then(res=>{ 
      //   this.data = [];
      //   this.selectedRowKeys = [];
      //   this.data = res.data;
      // });
    },
    onSelectChange(selectedRowKeys) {
      this.selectedRowKeys = selectedRowKeys;
    }
  },
};
</script>
<style scoped>

</style>
